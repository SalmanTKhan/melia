//--- Melia Script -----------------------------------------------------------
// Recovering Prestige
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Arune.
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

[QuestScript(60032)]
public class Quest60032Script : QuestScript
{
	protected override void Load()
	{
		SetId(60032);
		SetName("Recovering Prestige");
		SetDescription("Talk to Kupole Arune");

		AddPrerequisite(new LevelPrerequisite(154));
		AddPrerequisite(new CompletedPrerequisite("VPRISON512_MQ_05"));

		AddObjective("collect0", "Collect 7 Nuaele's Fragment(s)", new CollectItemObjective("VPRISON512_SQ_02_ITEM", 7));
		AddDrop("VPRISON512_SQ_02_ITEM", 10f, 57692, 57690, 57688);

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4466));

		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON512_SQ_02_01", "VPRISON512_SQ_02", "I will retrieve the fragments", "I will meet the Vakarine first"))
		{
			case 1:
				await dialog.Msg("VPRISON512_SQ_02_AG");
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

		if (character.Inventory.HasItem("VPRISON512_SQ_02_ITEM", 7))
		{
			character.Inventory.RemoveItem("VPRISON512_SQ_02_ITEM", 7);
			await dialog.Msg("VPRISON512_SQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

