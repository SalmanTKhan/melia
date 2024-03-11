//--- Melia Script -----------------------------------------------------------
// Kidnapped villagers (1) - Delete
//--- Description -----------------------------------------------------------
// Quest to Talk to the Miners' Village Mayor.
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

[QuestScript(8077)]
public class Quest8077Script : QuestScript
{
	protected override void Load()
	{
		SetId(8077);
		SetName("Kidnapped villagers (1) - Delete");
		SetDescription("Talk to the Miners' Village Mayor");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SOUT_Q_11_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 4 Novice Vubbe Archer(s) or Vubbe Scout(s)", new KillObjective(4, 57193, 57192));

		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_11_1", "SOUT_Q_11", "I'll save the village residents", "Take time to think for a while"))
		{
			case 1:
				await dialog.Msg("SOUT_Q_11_1_09");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

