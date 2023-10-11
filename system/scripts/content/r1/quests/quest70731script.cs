//--- Melia Script -----------------------------------------------------------
// A Long-Term Plan
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Sophia.
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

[QuestScript(70731)]
public class Quest70731Script : QuestScript
{
	protected override void Load()
	{
		SetId(70731);
		SetName("A Long-Term Plan");
		SetDescription("Talk with Alchemist Sophia");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ11"));

		AddObjective("collect0", "Collect 11 Blue Beetow Wings(s)", new CollectItemObjective("BRACKEN42_2_SQ12_1_ITEM", 11));
		AddDrop("BRACKEN42_2_SQ12_1_ITEM", 8f, "beetow_blue");

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("BRACKEN422_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN422_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN422_SQ_12_start", "BRACKEN42_2_SQ12", "I will help you until it is fully complete.", "I have done enough. Good day to you. I said good day!"))
		{
			case 1:
				await dialog.Msg("BRACKEN422_SQ_12_agree");
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

		if (character.Inventory.HasItem("BRACKEN42_2_SQ12_1_ITEM", 11) && character.Inventory.HasItem("BRACKEN42_2_SQ12_2_ITEM", 7))
		{
			character.Inventory.RemoveItem("BRACKEN42_2_SQ12_1_ITEM", 11);
			character.Inventory.RemoveItem("BRACKEN42_2_SQ12_2_ITEM", 7);
			await dialog.Msg("BRACKEN422_SQ_12_succ");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

