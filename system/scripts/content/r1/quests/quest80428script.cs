//--- Melia Script -----------------------------------------------------------
// Swore to Protect (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Yulia.
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

[QuestScript(80428)]
public class Quest80428Script : QuestScript
{
	protected override void Load()
	{
		SetId(80428);
		SetName("Swore to Protect (2)");
		SetDescription("Talk to Kupole Yulia");

		AddPrerequisite(new LevelPrerequisite(415));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_01"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23655));

		AddDialogHook("F_MAPLE_242_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_02_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_2_MQ_02_ST", "F_MAPLE_24_2_MQ_02", "We should get a move on.", "Let's rest for while."))
		{
			case 1:
				// Func/SCR_F_MAPLE_242_MQ_02_RUNNPC;
				dialog.HideNPC("F_MAPLE_242_MQ_01_NPC");
				await dialog.Msg("F_MAPLE_24_2_MQ_02_AFST");
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

		if (character.Inventory.HasItem("F_MAPLE_242_MQ_02_ITEM", 1))
		{
			character.Inventory.RemoveItem("F_MAPLE_242_MQ_02_ITEM", 1);
			ZoneServer.Instance.World.FindNPC("F_MAPLE_242_MQ_02_NPC2")?.PlayEffectLocal(character.Connection, "F_lineup014_yellow", 2f, "BOT");
			await dialog.Msg("F_MAPLE_24_2_MQ_02_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

