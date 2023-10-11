//--- Melia Script -----------------------------------------------------------
// Reconstruction of the Blessing (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Albina.
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

[QuestScript(40470)]
public class Quest40470Script : QuestScript
{
	protected override void Load()
	{
		SetId(40470);
		SetName("Reconstruction of the Blessing (3)");
		SetDescription("Talk to Albina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_1_SQ_110_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_100"));

		AddObjective("kill0", "Kill 1 Completed Magic Circle", new KillObjective(1, MonsterId.Farm47_Circle_01));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_ALBINA", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_ALBINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_110_ST", "FARM47_1_SQ_110", "I will destroy the magic circle", "I don't have time for that"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_1_SQ_110_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

