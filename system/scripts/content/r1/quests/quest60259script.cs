//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60259)]
public class Quest60259Script : QuestScript
{
	protected override void Load()
	{
		SetId(60259);
		SetName("Necessary Mistake (5)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(341));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB483_MQ_4"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY483_NERINGA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_VIVORA_2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB483_MQ_5_1", "FANTASYLIB483_MQ_5", "I will go right away", "I need to prepare"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1500");
				dialog.HideNPC("FLIBRARY483_NERINGA_NPC_2");
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

		await dialog.Msg("FANTASYLIB483_MQ_5_3");
		dialog.HideNPC("FLIBRARY483_VIVORA_2_NPC");
		dialog.UnHideNPC("FLIBRARY483_DANUTE_NPC");
		await dialog.Msg("FadeOutIN/3000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

