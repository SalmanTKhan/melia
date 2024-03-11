//--- Melia Script -----------------------------------------------------------
// Splendid Supply
//--- Description -----------------------------------------------------------
// Quest to Talk to Orsha Damage Recovery Team.
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

[QuestScript(92044)]
public class Quest92044Script : QuestScript
{
	protected override void Load()
	{
		SetId(92044);
		SetName("Splendid Supply");
		SetDescription("Talk to Orsha Damage Recovery Team");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_SQ_05"));

		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_SQ_06_1", "EP13_F_SIAULIAI_2_SQ_06", "I'll go with you", "I'll talk about it"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_2_SQ_06_1_1");
				// Func/EP13_F_SIAULIAI_2_SQ_06_HIDE_RUN;
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

		await dialog.Msg("EP13_F_SIAULIAI_2_SQ_06_3");
		// Func/EP13_F_SIAULIAI_2_SQ_06_HIDE_RUN_1;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Go to the Paupys Crossing with the Orsha Damage Recovery Team");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

