//--- Melia Script -----------------------------------------------------------
// Spiritual Poison (4)
//--- Description -----------------------------------------------------------
// Quest to Defeat the surging monsters.
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

[QuestScript(8314)]
public class Quest8314Script : QuestScript
{
	protected override void Load()
	{
		SetId(8314);
		SetName("Spiritual Poison (4)");
		SetDescription("Defeat the surging monsters");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_MQ_08_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_07"));

		AddObjective("kill0", "Kill 8 Red Puragi(s)", new KillObjective(8, MonsterId.Puragi_Red));

		AddDialogHook("KATYN18_OWL_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

