//--- Melia Script -----------------------------------------------------------
// The Thing That Should Not Let It Be
//--- Description -----------------------------------------------------------
// Quest to Speak with Goddess Lada.
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

[QuestScript(80046)]
public class Quest80046Script : QuestScript
{
	protected override void Load()
	{
		SetId(80046);
		SetName("The Thing That Should Not Let It Be");
		SetDescription("Speak with Goddess Lada");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_324_MQ_06_TRACK", "m_boss_scenario2");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_MQ_05"));

		AddObjective("kill0", "Kill 1 Zaura, Empowered by Giltine", new KillObjective(1, MonsterId.Boss_Zawra_Q1));

		AddReward(new ExpReward(491420, 491420));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2400));
		AddReward(new ItemReward("TreasureboxKey4", 1));

		AddDialogHook("ORCHARD324_LADA", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_LADA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_324_MQ_06_start", "ORCHARD_324_MQ_06", "I will come back after destroying it", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("NPCAin/ORCHARD324_LADA/IDLE/0");
				await Task.Delay(1000);
				character.PlayEffectLocal("F_buff_basic025_white_line");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_324_MQ_07");
	}
}

