//--- Melia Script -----------------------------------------------------------
// Wrong Faith (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager James.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(80082)]
public class Quest80082Script : QuestScript
{
	protected override void Load()
	{
		SetId(80082);
		SetName("Wrong Faith (3)");
		SetDescription("Talk to Villager James");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_4"));

		AddObjective("collect0", "Collect 9 The red blood of the demons(s)", new CollectItemObjective("ABBEY_35_3_EVIL_BLOOD", 9));
		AddDrop("ABBEY_35_3_EVIL_BLOOD", 10f, 57974, 57970, 57972);

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 64));
		AddReward(new ItemReward("Vis", 8244));

		AddDialogHook("ABBEY_35_3_VILLAGE_C_2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_VILLAGE_C_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_3_SQ_5_start", "ABBEY_35_3_SQ_5", "I will save you first", "The red blood of the demons", "Leave the vicinity"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ABBEY_35_3_SQ_5_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("ABBEY_35_3_EVIL_BLOOD", 9))
		{
			character.Inventory.RemoveItem("ABBEY_35_3_EVIL_BLOOD", 9);
			await dialog.Msg("ABBEY_35_3_SQ_5_succ");
			// Func/ABBEY_35_3_SQ_5_COMP;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY_35_3_SQ_6");
	}
}

