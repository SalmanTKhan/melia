//--- Melia Script -----------------------------------------------------------
// Build Barricade
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

[QuestScript(91094)]
public class Quest91094Script : QuestScript
{
	protected override void Load()
	{
		SetId(91094);
		SetName("Build Barricade");
		SetDescription("Talk to the Centurion Master");

		AddPrerequisite(new LevelPrerequisite(462));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_2"));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));

		AddDialogHook("EP14_1_FCASTLE2_MQ_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE2_MQ_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE2_MQ_3_SNPC_DLG1", "EP14_1_FCASTLE2_MQ_3", "I'll install it", "Leave"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE2_MQ_3_SNPC_DLG2");
				dialog.UnHideNPC("EP14_1_FCASTLE2_MQ_3_BEFORE1");
				dialog.UnHideNPC("EP14_1_FCASTLE2_MQ_3_BEFORE2");
				dialog.UnHideNPC("EP14_1_FCASTLE2_MQ_3_BEFORE3");
				dialog.UnHideNPC("EP14_1_FCASTLE2_MQ_3_BEFORE4");
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

		await dialog.Msg("EP14_1_FCASTLE2_MQ_3_CNPC_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

