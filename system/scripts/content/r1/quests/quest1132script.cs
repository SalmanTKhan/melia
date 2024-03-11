//--- Melia Script -----------------------------------------------------------
// Where the Sun Shines [Pyromancer Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(1132)]
public class Quest1132Script : QuestScript
{
	protected override void Load()
	{
		SetId(1132);
		SetName("Where the Sun Shines [Pyromancer Advancement] (1)");
		SetDescription("Talk to the Pyromancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PYROMANCER3_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(1, MonsterId.Boss_Chapparition_J1));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PYROMANCER3_1_select1", "JOB_PYROMANCER3_1", "I'll do it", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_PYROMANCER3_1_prog1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_PYROMANCER3_2");
	}
}

