//--- Melia Script -----------------------------------------------------------
// Kupole Rescue Mission (1)
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

[QuestScript(80130)]
public class Quest80130Script : QuestScript
{
	protected override void Load()
	{
		SetId(80130);
		SetName("Kupole Rescue Mission (1)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_4"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONECAVE_52_2_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_2_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_5_start", "LIMESTONE_52_2_MQ_5", "We should investigate the devices we found on our way here.", "I'm not sure"))
		{
			case 1:
				await dialog.Msg("LIMESTONE_52_2_MQ_5_agree");
				// Func/LIMESTONE_52_2_REENTER_RUN;
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

		await dialog.Msg("LIMESTONE_52_2_MQ_5_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

