//--- Melia Script -----------------------------------------------------------
// Leaving None Behind
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

[QuestScript(92046)]
public class Quest92046Script : QuestScript
{
	protected override void Load()
	{
		SetId(92046);
		SetName("Leaving None Behind");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_SQ_01"));

		AddReward(new ItemReward("Vis", 140740));
		AddReward(new ItemReward("expCard18", 10));

		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_SQ_02_1", "EP13_F_SIAULIAI_3_SQ_02", "Alright", "It's hopeless"))
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

		await dialog.Msg("EP13_F_SIAULIAI_3_SQ_02_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}
