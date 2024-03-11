//--- Melia Script -----------------------------------------------------------
// Suspicious Treasure Chest
//--- Description -----------------------------------------------------------
// Quest to Suspicious Treasure Chest.
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

[QuestScript(8081)]
public class Quest8081Script : QuestScript
{
	protected override void Load()
	{
		SetId(8081);
		SetName("Suspicious Treasure Chest");
		SetDescription("Suspicious Treasure Chest");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU_OUT_BOSS_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(11));

		AddObjective("kill0", "Kill 1 Red Vubbe Fighter", new KillObjective(1, MonsterId.Boss_Goblin_Warrior_Red));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 143));

		AddDialogHook("TREASUREBOX_BUBE", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE", "BeforeEnd", BeforeEnd);
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

