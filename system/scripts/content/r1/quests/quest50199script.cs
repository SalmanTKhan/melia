//--- Melia Script -----------------------------------------------------------
// The Goddess' Flower (7)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gherriti.
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

[QuestScript(50199)]
public class Quest50199Script : QuestScript
{
	protected override void Load()
	{
		SetId(50199);
		SetName("The Goddess' Flower (7)");
		SetDescription("Talk with Priest Gherriti");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN43_1_SQ7_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(307));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_1_SQ6"));

		AddObjective("kill0", "Kill 1 Rytaswort", new KillObjective(1, MonsterId.Boss_RytaSwort_Q1));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14122));

		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_1_SQ7_START1", "BRACKEN43_1_SQ7", "I will burn the flower.", "Just leave it"))
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

		// Func/TrackInTrack/BRACKEN431_SUBQ7_COMPLETE_TRACK;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

