//--- Melia Script -----------------------------------------------------------
// Search for the survivors
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

[QuestScript(91111)]
public class Quest91111Script : QuestScript
{
	protected override void Load()
	{
		SetId(91111);
		SetName("Search for the survivors");
		SetDescription("Talk to General Ramin");

		AddPrerequisite(new LevelPrerequisite(466));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_2"));

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

		switch (await dialog.Select("EP14_1_FCASTLE4_MQ_3_SNPC_DLG1", "EP14_1_FCASTLE4_MQ_3", "I'll follow your order", "I need to prepare to follow your order"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.UnHideNPC("EP14_1_FCASTLE4_PAJAUTA_1");
				// Func/SCR_EP14_1_F_CASTLE_4_PAJAUTA_CANCEL;
				dialog.UnHideNPC("EP14_1_FCASTLE4_MQ_3_HIDDEN");
				dialog.UnHideNPC("EP14_1_FCASTLE4_MQ_3_NPC1");
				await dialog.Msg("EP14_1_FCASTLE4_MQ_3_SNPC_DLG2");
				await dialog.Msg("EP14_1_FCASTLE4_MQ_3_SNPC_DLG3");
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

		await dialog.Msg("EP14_1_FCASTLE4_MQ_3_CNPC_DLG1");
		dialog.HideNPC("EP14_1_FCASTLE4_MQ_3_HIDDEN");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

