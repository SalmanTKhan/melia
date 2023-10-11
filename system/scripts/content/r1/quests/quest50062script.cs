//--- Melia Script -----------------------------------------------------------
// The seal which the monster possesses
//--- Description -----------------------------------------------------------
// Quest to Talk to Wilhelmina Carriot.
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

[QuestScript(50062)]
public class Quest50062Script : QuestScript
{
	protected override void Load()
	{
		SetId(50062);
		SetName("The seal which the monster possesses");
		SetDescription("Talk to Wilhelmina Carriot");

		AddPrerequisite(new LevelPrerequisite(204));

		AddObjective("collect0", "Collect 12 Ruklys Army Seal(s)", new CollectItemObjective("UNDERFORTRESS66_SQ_ITEM01", 12));
		AddObjective("collect1", "Collect 12 Parchment(s)", new CollectItemObjective("UNDERFORTRESS66_SQ_ITEM02", 12));
		AddDrop("UNDERFORTRESS66_SQ_ITEM01", 10f, "Chafperor_mage_purple");
		AddDrop("UNDERFORTRESS66_SQ_ITEM02", 10f, "ticen_mage_blue");

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH64_KARRIAT", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_KARRIAT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_66_SQ010_startnpc01", "UNDERFORTRESS_66_SQ010", "I will collect them", "I won't go in again"))
		{
			case 1:
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

		if (character.Inventory.HasItem("UNDERFORTRESS66_SQ_ITEM01", 12) && character.Inventory.HasItem("UNDERFORTRESS66_SQ_ITEM02", 12))
		{
			character.Inventory.RemoveItem("UNDERFORTRESS66_SQ_ITEM01", 12);
			character.Inventory.RemoveItem("UNDERFORTRESS66_SQ_ITEM02", 12);
			await dialog.Msg("UNDERFORTRESS_66_SQ010_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

