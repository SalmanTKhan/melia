//--- Melia Script -----------------------------------------------------------
// Demon's Defense Plan (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91107)]
public class Quest91107Script : QuestScript
{
	protected override void Load()
	{
		SetId(91107);
		SetName("Demon's Defense Plan (5)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(464));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE3_MQ_6"));

		AddObjective("kill0", "Kill 20 Blickferret Spearman(s) or Blickferret Counterbattery(s) or Blickferret Swordsman(s)", new KillObjective(20, 59698, 59699, 59700));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29232));

		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE3_MQ_7_SNPC_DLG1", "EP14_1_FCASTLE3_MQ_7", "Let's move", "Wait for a while"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE3_MQ_7_SNPC_DLG2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP14_1_FCASTLE3_MQ_7_CNPC_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

