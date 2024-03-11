//--- Melia Script -----------------------------------------------------------
// The Truth Behind the Epidemic (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jugrinas.
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

[QuestScript(30281)]
public class Quest30281Script : QuestScript
{
	protected override void Load()
	{
		SetId(30281);
		SetName("The Truth Behind the Epidemic (1)");
		SetDescription("Talk to Jugrinas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES_21_2_SQ_8_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(322));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_7"));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_2_SQ_8_select", "WTREES_21_2_SQ_8", "I'll go get the epidemic detectors.", "I'm afraid it's time for me to say goodbye."))
		{
			case 1:
				await dialog.Msg("WTREES_21_2_SQ_8_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

