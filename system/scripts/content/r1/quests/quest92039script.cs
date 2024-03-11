//--- Melia Script -----------------------------------------------------------
// Lack of Everything
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

[QuestScript(92039)]
public class Quest92039Script : QuestScript
{
	protected override void Load()
	{
		SetId(92039);
		SetName("Lack of Everything");
		SetDescription("Talk to Orsha Damage Recovery Team");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_SQ_05"));

		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_SQ_01_1", "EP13_F_SIAULIAI_2_SQ_01", "I will discuss the matter with Pajauta", "I guess there's no other way"))
		{
			case 1:
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

		await dialog.Msg("EP13_F_SIAULIAI_2_SQ_01_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

