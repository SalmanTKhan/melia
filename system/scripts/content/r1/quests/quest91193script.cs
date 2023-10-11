//--- Melia Script -----------------------------------------------------------
// Greed of a Merchant (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Greedy Merchantwoman.
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

[QuestScript(91193)]
public class Quest91193Script : QuestScript
{
	protected override void Load()
	{
		SetId(91193);
		SetName("Greed of a Merchant (2)");
		SetDescription("Talk to the Greedy Merchantwoman");

		AddPrerequisite(new LevelPrerequisite(485));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_ABBEY2_SQ1"));

		AddObjective("collect0", "Collect 25 Jewel fragment of Vubbe(s)", new CollectItemObjective("EP15_1_ABBEY2_SQ2_ITEM", 25));
		AddDrop("EP15_1_ABBEY2_SQ2_ITEM", 2f, 59777, 59780, 59778);

		AddReward(new ExpReward(4200000000, 4200000000));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY2_SQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_ABBEY2_SQ1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_ABBEY2_SQ2_DLG1", "EP15_1_ABBEY2_SQ2", "Alright", "I have other things to do."))
		{
			case 1:
				await dialog.Msg("EP15_1_ABBEY2_SQ2_DLG2");
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

		if (character.Inventory.HasItem("EP15_1_ABBEY2_SQ2_ITEM", 25))
		{
			character.Inventory.RemoveItem("EP15_1_ABBEY2_SQ2_ITEM", 25);
			await dialog.Msg("EP15_1_ABBEY2_SQ2_DLG3");
			await dialog.Msg("FadeOutIN/2500");
			dialog.HideNPC("EP15_1_ABBEY2_SQ1_NPC");
			// Func/SCR_EP15_1_ABBEY2_SQ2_balloontext;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

