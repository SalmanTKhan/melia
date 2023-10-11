//--- Melia Script -----------------------------------------------------------
// Bullet Marker's Property Application
//--- Description -----------------------------------------------------------
// Quest to Talk with the Bullet Marker Master.
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

[QuestScript(1163)]
public class Quest1163Script : QuestScript
{
	protected override void Load()
	{
		SetId(1163);
		SetName("Bullet Marker's Property Application");
		SetDescription("Talk with the Bullet Marker Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_BULLETMARKER1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("BULLETMARKER_MASTER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_BULLETMARKER1_select1", "JOB_BULLETMARKER1", "I'll accept the training", "I won't accept."))
		{
			case 1:
				await dialog.Msg("JOB_BULLETMARKER1_agree1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

