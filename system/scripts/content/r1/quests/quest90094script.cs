//--- Melia Script -----------------------------------------------------------
// Hidden Room
//--- Description -----------------------------------------------------------
// Quest to Inspect the Hidden Chamber.
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

[QuestScript(90094)]
public class Quest90094Script : QuestScript
{
	protected override void Load()
	{
		SetId(90094);
		SetName("Hidden Room");
		SetDescription("Inspect the Hidden Chamber");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CATACOMB_25_4_SQ_120_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_110"));

		AddObjective("kill0", "Kill 1 Specter Monarch", new KillObjective(1, MonsterId.Boss_Spector_M_Q3));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_120", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

