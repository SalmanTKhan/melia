//--- Melia Script -----------------------------------------------------------
// Retiarius and the Net
//--- Description -----------------------------------------------------------
// Quest to Talk with the Retiarius Master.
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

[QuestScript(1164)]
public class Quest1164Script : QuestScript
{
	protected override void Load()
	{
		SetId(1164);
		SetName("Retiarius and the Net");
		SetDescription("Talk with the Retiarius Master");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "JOB_RETIARII1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("RETIARII_MASTER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RETIARII1_select1", "JOB_RETIARII1", "I'll accept the training", "I won't accept."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

