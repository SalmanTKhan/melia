//--- Melia Script -----------------------------------------------------------
// Reassemble the Troop (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(91086)]
public class Quest91086Script : QuestScript
{
	protected override void Load()
	{
		SetId(91086);
		SetName("Reassemble the Troop (1)");
		SetDescription("Talk to the Centurion Master");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE1_MQ_1"));

		AddObjective("kill0", "Kill 15 Blickferret Spearman(s) or Blickferret Charger(s) or Blickferret Counterbattery(s)", new KillObjective(15, 59692, 59693, 59694));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP14_1_F_CASTLE_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_1_FOLLOW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE1_MQ_2_SNPC_DLG1", "EP14_1_FCASTLE1_MQ_2", "I'll help you", "It's hard to help"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("EP14_1_F_CASTLE_1_NPC1");
				dialog.HideNPC("EP14_1_F_CASTLE_1_NPC2");
				// Func/SCR_EP14_1_F_CASTLE_1_KRAJICEK_SUMMON;
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

		await dialog.Msg("EP14_1_FCASTLE1_MQ_2_CNPC_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

