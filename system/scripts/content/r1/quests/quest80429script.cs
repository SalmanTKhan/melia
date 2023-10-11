//--- Melia Script -----------------------------------------------------------
// Swore to Protect (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Ilona.
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

[QuestScript(80429)]
public class Quest80429Script : QuestScript
{
	protected override void Load()
	{
		SetId(80429);
		SetName("Swore to Protect (3)");
		SetDescription("Talk to Kupole Ilona");

		AddPrerequisite(new LevelPrerequisite(415));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_02"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23655));

		AddDialogHook("F_MAPLE_242_MQ_02_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_03_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_2_MQ_03_ST", "F_MAPLE_24_2_MQ_03", "I can help.", "I can't do that, sorry."))
		{
			case 1:
				dialog.HideNPC("F_MAPLE_242_MQ_02_NPC1");
				dialog.HideNPC("F_MAPLE_242_MQ_02_NPC2");
				// Func/SCR_F_MAPLE_242_MQ_03_RUNNPC;
				await dialog.Msg("F_MAPLE_24_2_MQ_03_AFST");
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

		await dialog.Msg("F_MAPLE_24_2_MQ_03_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

