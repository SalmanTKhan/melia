//--- Melia Script -----------------------------------------------------------
// Before the Demon King Arrives (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80164)]
public class Quest80164Script : QuestScript
{
	protected override void Load()
	{
		SetId(80164);
		SetName("Before the Demon King Arrives (1)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(301));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_2"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_5_MQ_3_start", "LIMESTONE_52_5_MQ_3", "Is there any way we can do it?", "Let's just give up on it."))
		{
			case 1:
				// Func/LIMESTONE_52_5_REENTER_RUN;
				// Func/LIMESTONE_52_5_MQ_3_ATTACH;
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("LIMESTONE_52_5_MQ_3_ST02");
				await dialog.Msg("Alright");
				await dialog.Msg("LIMESTONE_52_5_MQ_3_ST");
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

		// Func/LIMESTONE_52_5_MQ_3_DETACH;
		await dialog.Msg("LIMESTONE_52_5_MQ_3_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

