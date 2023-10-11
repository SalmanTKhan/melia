//--- Melia Script -----------------------------------------------------------
// Marks of a legend(5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Woognis.
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

[QuestScript(50215)]
public class Quest50215Script : QuestScript
{
	protected override void Load()
	{
		SetId(50215);
		SetName("Marks of a legend(5)");
		SetDescription("Talk to Woognis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN43_3_SQ5_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ4"));

		AddObjective("kill0", "Kill 5 Romplenuka(s)", new KillObjective(5, MonsterId.Rompelnuka));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14398));

		AddDialogHook("BRACKEN433_SUBQ3_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ5_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ5_START1", "BRACKEN43_3_SQ5", "Go to Jenonhas", "Say that you will go there later"))
		{
			case 1:
				dialog.UnHideNPC("BRACKEN433_SUBQ5_NPC1");
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

		await dialog.Msg("BRACKEN43_3_SQ5_SUCC1");
		dialog.HideNPC("BRACKEN433_SUBQ1_NPC1");
		dialog.UnHideNPC("BRACKEN433_SUBQ1_NPC2");
		dialog.HideNPC("BRACKEN433_SUBQ3_NPC1");
		dialog.UnHideNPC("BRACKEN433_SUBQ3_NPC2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

