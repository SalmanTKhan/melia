//--- Melia Script -----------------------------------------------------------
// Remove Siege
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(91112)]
public class Quest91112Script : QuestScript
{
	protected override void Load()
	{
		SetId(91112);
		SetName("Remove Siege");
		SetDescription("Talk to General Ramin");

		AddPrerequisite(new LevelPrerequisite(466));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_3"));

		AddObjective("kill0", "Kill 30 Grasme Bird(s) or Grasme Crow(s) or Grasme Raven(s)", new KillObjective(30, 59702, 59703, 59704));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29358));

		AddDialogHook("EP14_1_FCASTLE4_MQ_2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE4_MQ_2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE4_MQ_4_SNPC_DLG1", "EP14_1_FCASTLE4_MQ_4", "I'm listening", "I have other things to do first"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE4_MQ_4_SNPC_DLG2");
				await dialog.Msg("EP14_1_FCASTLE4_MQ_4_SNPC_DLG3");
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

		await dialog.Msg("EP14_1_FCASTLE4_MQ_4_CNPC_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

