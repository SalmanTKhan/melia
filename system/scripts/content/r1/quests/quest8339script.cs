//--- Melia Script -----------------------------------------------------------
// Attack of Biteregina
//--- Description -----------------------------------------------------------
// Quest to Attack of Biteregina.
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

[QuestScript(8339)]
public class Quest8339Script : QuestScript
{
	protected override void Load()
	{
		SetId(8339);
		SetName("Attack of Biteregina");
		SetDescription("Attack of Biteregina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_SUB03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(1, MonsterId.Boss_BiteRegina_Q2));

		AddDialogHook("KATYN18_SUB_03", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_SUB_03", "BeforeEnd", BeforeEnd);
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

