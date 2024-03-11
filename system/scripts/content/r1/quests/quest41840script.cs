//--- Melia Script -----------------------------------------------------------
// For Them
//--- Description -----------------------------------------------------------
// Quest to Talk to the Laker Leader.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(41840)]
public class Quest41840Script : QuestScript
{
	protected override void Load()
	{
		SetId(41840);
		SetName("For Them");
		SetDescription("Talk to the Laker Leader");

		AddPrerequisite(new LevelPrerequisite(395));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_3_SQ_7"));

		AddObjective("collect0", "Collect 10 Paralysis Pouch(s)", new CollectItemObjective("F_3CMLAKE_27_3_SQ_8_ITEM", 10));
		AddDrop("F_3CMLAKE_27_3_SQ_8_ITEM", 9f, "Frocoli");

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_3_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_3_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_3_SQ_8_DLG1", "F_3CMLAKE_27_3_SQ_8", "I will gather the materials for you.", "I want to rest for a bit."))
		{
			case 1:
				// Func/FADEFUNC;
				dialog.HideNPC("F_3CMLAKE_27_3_NPC4");
				dialog.UnHideNPC("F_3CMLAKE_27_3_NPC3");
				// Func/SETPOS;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("F_3CMLAKE_27_3_SQ_8_ITEM", 10))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_27_3_SQ_8_ITEM", 10);
			await dialog.Msg("F_3CMLAKE_27_3_SQ_8_DLG3");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

