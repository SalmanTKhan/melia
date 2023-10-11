//--- Melia Script -----------------------------------------------------------
// Ramin the Great General 
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91110)]
public class Quest91110Script : QuestScript
{
	protected override void Load()
	{
		SetId(91110);
		SetName("Ramin the Great General ");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(466));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_1"));

		AddReward(new ExpReward(1046153856, 1046153856));

		AddDialogHook("EP14_1_F_CASTLE_4_FOLLOW_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE4_MQ_2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE4_MQ_2_SNPC_DLG1", "EP14_1_FCASTLE4_MQ_2", "Let's move", "Rather rest a bit"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE4_MQ_2_SNPC_DLG2");
				dialog.UnHideNPC("EP14_1_FCASTLE4_MQ_2_HIDDEN");
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

		await dialog.Msg("EP14_1_FCASTLE4_MQ_2_CNPC_DLG1");
		dialog.HideNPC("EP14_1_FCASTLE4_MQ_2_HIDDEN");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

