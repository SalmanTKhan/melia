//--- Melia Script -----------------------------------------------------------
// Crafting Plant Supplement (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90097)]
public class Quest90097Script : QuestScript
{
	protected override void Load()
	{
		SetId(90097);
		SetName("Crafting Plant Supplement (2)");
		SetDescription("Talk to Kupole Lina");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_20"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("MAPLE_25_3_LINA", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_LINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_30_ST", "MAPLE_25_3_SQ_30", "The autumn leaves, here I come.", "Please wait a little."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_30_AG");
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

		if (character.Inventory.HasItem("MAPLE_25_3_SQ_30_ITEM", 5))
		{
			character.Inventory.RemoveItem("MAPLE_25_3_SQ_30_ITEM", 5);
			await dialog.Msg("MAPLE_25_3_SQ_30_SU");
			await dialog.Msg("NPCAin/MAPLE_25_3_LINA/ATK/0");
			ZoneServer.Instance.World.FindNPC("MAPLE_25_3_LINA")?.PlayEffectLocal(character.Connection, "F_buff_basic023_red_fire", 2f, "BOT");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

