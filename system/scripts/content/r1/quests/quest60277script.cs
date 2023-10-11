//--- Melia Script -----------------------------------------------------------
// Shadow of the Black Wing (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(60277)]
public class Quest60277Script : QuestScript
{
	protected override void Load()
	{
		SetId(60277);
		SetName("Shadow of the Black Wing (6)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB485_MQ_6_TRACK", "m_boss_scenario3");

		AddPrerequisite(new LevelPrerequisite(347));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB485_MQ_5"));

		AddObjective("kill0", "Kill 1 Demon Lord Warpulis", new KillObjective(1, MonsterId.Boss_Warpulis_Q1));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY485_NERINGA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY485_NERINGA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB485_MQ_6_1", "FANTASYLIB485_MQ_6", "I will fight back.", "I need to prepare"))
		{
			case 1:
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

		await dialog.Msg("FANTASYLIB485_MQ_6_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

