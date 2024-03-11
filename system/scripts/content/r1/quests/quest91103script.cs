//--- Melia Script -----------------------------------------------------------
// Demon's Defense Plan (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta about the next plan.
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

[QuestScript(91103)]
public class Quest91103Script : QuestScript
{
	protected override void Load()
	{
		SetId(91103);
		SetName("Demon's Defense Plan (2)");
		SetDescription("Talk to Pajauta about the next plan");

		AddPrerequisite(new LevelPrerequisite(464));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE3_MQ_2"));

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

		switch (await dialog.Select("EP14_1_FCASTLE3_MQ_3_SNPC_DLG1", "EP14_1_FCASTLE3_MQ_3", "I agree on finding the Base", "Wait for a while"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE3_MQ_3_SNPC_DLG2");
				dialog.UnHideNPC("EP14_1_FCASTLE3_MQ_3_TRACE");
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

		await dialog.Msg("EP14_1_FCASTLE3_MQ_3_CNPC_DLG1");
		dialog.HideNPC("EP14_1_FCASTLE3_MQ_3_TRACE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

