//--- Melia Script -----------------------------------------------------------
// Resolve the Tussle (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(91095)]
public class Quest91095Script : QuestScript
{
	protected override void Load()
	{
		SetId(91095);
		SetName("Resolve the Tussle (1)");
		SetDescription("Talk to the Centurion Master");

		AddPrerequisite(new LevelPrerequisite(462));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_3"));

		AddObjective("kill0", "Kill 20 Blickferret Fighter(s) or Blickferret Swordsman(s) or Blickferret Shielder(s)", new KillObjective(20, 59695, 59696, 59697));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));

		AddDialogHook("EP14_1_FCASTLE2_MQ_1_NPC1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE2_MQ_4_SNPC_DLG1", "EP14_1_FCASTLE2_MQ_4", "I'll go find the soliders", "Say that you have better things to do"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE2_MQ_4_SNPC_DLG2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_1_FCASTLE2_MQ_5");
	}
}

