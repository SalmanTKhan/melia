//--- Melia Script -----------------------------------------------------------
// Completed Preparations
//--- Description -----------------------------------------------------------
// Quest to Talk to Horacius.
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

[QuestScript(40471)]
public class Quest40471Script : QuestScript
{
	protected override void Load()
	{
		SetId(40471);
		SetName("Completed Preparations");
		SetDescription("Talk to Horacius");

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_040"), new CompletedPrerequisite("FARM47_1_SQ_110"), new CompletedPrerequisite("FARM47_1_SQ_070"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_LEADER", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_LEADER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_121_ST", "FARM47_1_SQ_121", "Listen to the story", "You don't need to listen to it anymore"))
		{
			case 1:
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

		await dialog.Msg("FARM47_1_SQ_121_COMP");
		dialog.UnHideNPC("FARM47_2_DIARY");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

