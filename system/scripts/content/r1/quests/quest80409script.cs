//--- Melia Script -----------------------------------------------------------
// Flowers and Butterflies (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Astra.
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

[QuestScript(80409)]
public class Quest80409Script : QuestScript
{
	protected override void Load()
	{
		SetId(80409);
		SetName("Flowers and Butterflies (2)");
		SetDescription("Talk to Kupole Astra");

		AddPrerequisite(new LevelPrerequisite(408));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_3_MQ_01"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23256));

		AddDialogHook("F_MAPLE_243_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_243_MQ_01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_3_MQ_02_ST", "F_MAPLE_24_3_MQ_02", "I'll have a look.", "No, I don't think I can do that."))
		{
			case 1:
				await dialog.Msg("F_MAPLE_24_3_MQ_02_AFST");
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

		await dialog.Msg("F_MAPLE_24_3_MQ_02_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

