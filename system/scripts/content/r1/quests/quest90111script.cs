//--- Melia Script -----------------------------------------------------------
// Inspect Herb (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Cesaris.
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

[QuestScript(90111)]
public class Quest90111Script : QuestScript
{
	protected override void Load()
	{
		SetId(90111);
		SetName("Inspect Herb (2)");
		SetDescription("Talk to Herbalist Cesaris");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_1_SQ_30"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("MAPLE_25_1_SQ_ITEM2", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("MAPLE_25_1_CEZARIS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_CEZARIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_40_ST", "MAPLE_25_1_SQ_40", "I'll go there", "I can't do it."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_40_AG");
				// Func/MAPLE_25_1_SQ_40_DOG_RUN;
				dialog.HideNPC("MAPLE_25_1_SQ_40_DOG");
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

		if (character.Inventory.HasItem("MAPLE_25_1_SQ_40_ITEM2", 3))
		{
			character.Inventory.RemoveItem("MAPLE_25_1_SQ_40_ITEM2", 3);
			dialog.UnHideNPC("MAPLE_25_1_SQ_40_DOG");
			await dialog.Msg("MAPLE_25_1_SQ_40_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

