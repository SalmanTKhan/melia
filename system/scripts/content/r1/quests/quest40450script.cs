//--- Melia Script -----------------------------------------------------------
// Reconstruction of the Blessing (1)
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

[QuestScript(40450)]
public class Quest40450Script : QuestScript
{
	protected override void Load()
	{
		SetId(40450);
		SetName("Reconstruction of the Blessing (1)");
		SetDescription("Talk to Albina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_1_SQ_090_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_080"));

		AddObjective("kill0", "Kill 1 Kirmeleech", new KillObjective(1, MonsterId.Boss_Kimeleech_Q1));
		AddObjective("kill1", "Kill 1 Completed Magic Circle", new KillObjective(1, MonsterId.Farm47_Circle_01));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_ALBINA", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_ALBINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_090_ST", "FARM47_1_SQ_090", "I will eliminate the monsters", "About the reason that the monster sit down", "Reject since it's scary"))
		{
			case 1:
				await dialog.Msg("FARM47_1_SQ_090_AC");
				dialog.UnHideNPC("FARM47_FENCE_WALL");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("FARM47_1_SQ_090_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_1_SQ_090_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

