//--- Melia Script -----------------------------------------------------------
// To protect the Orsha
//--- Description -----------------------------------------------------------
// Quest to Talk to the Goddess Lada.
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

[QuestScript(91040)]
public class Quest91040Script : QuestScript
{
	protected override void Load()
	{
		SetId(91040);
		SetName("To protect the Orsha");
		SetDescription("Talk to the Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_01"));

		AddObjective("kill0", "Kill 20 Darbas Carrier(s) or Darbas Loader(s) or Darbas Miner(s)", new KillObjective(20, 59580, 59581, 59582));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_02_DLG1", "EP13_F_SIAULIAI_2_MQ_02", "I will stop the monsters heading to the Orsha", "I will handle other place's work first"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_2_MQ_02_DLG2");
				// Func/SCR_EP13_F_SIAULIAI_2_MQ_LADA_1_HIDE;
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

		await dialog.Msg("EP13_F_SIAULIAI_2_MQ_02_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

