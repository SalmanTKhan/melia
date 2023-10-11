//--- Melia Script -----------------------------------------------------------
// Emergency Measures
//--- Description -----------------------------------------------------------
// Quest to Talk to the Injured Soldier.
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

[QuestScript(41812)]
public class Quest41812Script : QuestScript
{
	protected override void Load()
	{
		SetId(41812);
		SetName("Emergency Measures");
		SetDescription("Talk to the Injured Soldier");

		AddPrerequisite(new LevelPrerequisite(388));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_1_SQ_1"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_1_SQ_2_DLG1", "F_3CMLAKE_27_1_SQ_2", "Okay, I can help you.", "I really need some rest, sorry."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_1_SQ_2_DLG2");
				dialog.UnHideNPC("F_3CMLAKE_27_1_SQ2_HNPC");
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

		if (character.Inventory.HasItem("F_3CMLAKE_27_1_SQ_2_ITEM2", 8))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_27_1_SQ_2_ITEM2", 8);
			await dialog.Msg("F_3CMLAKE_27_1_SQ_2_DLG4");
			dialog.HideNPC("F_3CMLAKE_27_1_SQ2_HNPC");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_1_SQ_3");
	}
}

