//--- Melia Script -----------------------------------------------------------
// Curiosity Killed the Epigraphist
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Schmid.
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

[QuestScript(8729)]
public class Quest8729Script : QuestScript
{
	protected override void Load()
	{
		SetId(8729);
		SetName("Curiosity Killed the Epigraphist");
		SetDescription("Talk to Epigraphist Schmid");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAIN37_MQ07_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(96));
		AddPrerequisite(new CompletedPrerequisite("REMAIN37_SQ07"));

		AddObjective("kill0", "Kill 1 Magburk", new KillObjective(1, MonsterId.Boss_MagBurk));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_SMEADE", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_SQ08_01", "REMAIN37_SQ08", "I'll stay with you till the end", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

