//--- Melia Script -----------------------------------------------------------
// Ripped Ragdolls
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Representative Morkus.
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

[QuestScript(90122)]
public class Quest90122Script : QuestScript
{
	protected override void Load()
	{
		SetId(90122);
		SetName("Ripped Ragdolls");
		SetDescription("Talk to Refugee Representative Morkus");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_2_SQ_10"));

		AddObjective("collect0", "Collect 8 Rag Doll Fragment(s)", new CollectItemObjective("MAPLE_25_2_SQ_40_ITEM", 8));
		AddDrop("MAPLE_25_2_SQ_40_ITEM", 9f, 58541, 58542, 58543);

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_2_SQ_40_ST", "MAPLE_25_2_SQ_40", "I will bring back the rag doll by defeating some monsters.", "I don't think it is."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_2_SQ_40_AG");
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

		if (character.Inventory.HasItem("MAPLE_25_2_SQ_40_ITEM", 8))
		{
			character.Inventory.RemoveItem("MAPLE_25_2_SQ_40_ITEM", 8);
			await dialog.Msg("MAPLE_25_2_SQ_40_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

