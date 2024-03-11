//--- Melia Script -----------------------------------------------------------
// Light the Fire (2)
//--- Description -----------------------------------------------------------
// Quest to Light up the stone lantern with the Burning Stone.
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

[QuestScript(8429)]
public class Quest8429Script : QuestScript
{
	protected override void Load()
	{
		SetId(8429);
		SetName("Light the Fire (2)");
		SetDescription("Light up the stone lantern with the Burning Stone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA1F_SQ_02_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(87));
		AddPrerequisite(new CompletedPrerequisite("ZACHA1F_SQ_01"));

		AddObjective("kill0", "Kill 1 Clymen", new KillObjective(1, MonsterId.Boss_Clymen_Q1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("TreasureboxKey2", 1));
		AddReward(new ItemReward("Vis", 1740));

		AddDialogHook("ZACHA1F_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA1F_SQ_02", "BeforeEnd", BeforeEnd);
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

