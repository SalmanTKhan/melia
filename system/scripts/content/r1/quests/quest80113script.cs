//--- Melia Script -----------------------------------------------------------
// Kupole in Danger (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena at Khonot Forest.
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

[QuestScript(80113)]
public class Quest80113Script : QuestScript
{
	protected override void Load()
	{
		SetId(80113);
		SetName("Kupole in Danger (1)");
		SetDescription("Talk to Kupole Medena at Khonot Forest");

		AddPrerequisite(new LevelPrerequisite(287));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("BRAKEN_42_1_MEDENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_MEDENA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_1_MQ_1_start", "LIMESTONE_52_1_MQ_1", "Ask what's going on", "Not really my problem"))
		{
			case 1:
				await dialog.Msg("LIMESTONE_52_1_MQ_1_agree");
				// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
				dialog.HideNPC("BRAKEN_42_1_MEDENA");
				await Task.Delay(1000);
				// Func/SCR_LIMESTONE_52_1_MQ_1_ST_01;
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

		await dialog.Msg("LIMESTONE_52_1_MQ_1_succ");
		dialog.UnHideNPC("LIMSTONE_52_1_CART");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

