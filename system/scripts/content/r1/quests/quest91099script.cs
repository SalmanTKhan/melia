//--- Melia Script -----------------------------------------------------------
// Task of Each One
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

[QuestScript(91099)]
public class Quest91099Script : QuestScript
{
	protected override void Load()
	{
		SetId(91099);
		SetName("Task of Each One");
		SetDescription("Talk to the Centurion Master");

		AddPrerequisite(new LevelPrerequisite(462));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_7"));

		AddObjective("kill0", "Kill 15 Blickferret Fighter(s) or Blickferret Swordsman(s) or Blickferret Shielder(s)", new KillObjective(15, 59695, 59696, 59697));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));

		AddDialogHook("EP14_1_FCASTLE2_MQ_7_NPC1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE2_MQ_8_SNPC_DLG1", "EP14_1_FCASTLE2_MQ_8", "I'll prepare the way to the Delmore Outskirts", "I have other things to do first"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE2_MQ_8_SNPC_DLG2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

