//--- Melia Script -----------------------------------------------------------
// Re-Confirm (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Costas.
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

[QuestScript(90088)]
public class Quest90088Script : QuestScript
{
	protected override void Load()
	{
		SetId(90088);
		SetName("Re-Confirm (1)");
		SetDescription("Talk to Costas");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_50"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_KOSTAS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_SQ_KOSTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_25_4_SQ_60_ST", "CATACOMB_25_4_SQ_60", "I will bring back Doctrine and glory to the order.", "Please wait a bit"))
		{
			case 1:
				await dialog.Msg("CATACOMB_25_4_SQ_60_AG");
				dialog.UnHideNPC("CATACOMB_25_4_SQ_60_1");
				dialog.UnHideNPC("CATACOMB_25_4_SQ_60_2");
				dialog.UnHideNPC("CATACOMB_25_4_SQ_60_3");
				dialog.UnHideNPC("CATACOMB_25_4_SQ_60_4");
				dialog.HideNPC("CATACOMB_25_4_SQ_JAUNIUS2");
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

		if (character.Inventory.HasItem("CATACOMB_25_4_SQ_60_ITEM1", 1) && character.Inventory.HasItem("CATACOMB_25_4_SQ_60_ITEM2", 1) && character.Inventory.HasItem("CATACOMB_25_4_SQ_60_ITEM3", 1) && character.Inventory.HasItem("CATACOMB_25_4_SQ_90_ITEM", 1))
		{
			character.Inventory.RemoveItem("CATACOMB_25_4_SQ_60_ITEM1", 1);
			character.Inventory.RemoveItem("CATACOMB_25_4_SQ_60_ITEM2", 1);
			character.Inventory.RemoveItem("CATACOMB_25_4_SQ_60_ITEM3", 1);
			character.Inventory.RemoveItem("CATACOMB_25_4_SQ_90_ITEM", 1);
			await dialog.Msg("CATACOMB_25_4_SQ_60_SU");
			dialog.HideNPC("CATACOMB_25_4_SQ_60_1");
			dialog.HideNPC("CATACOMB_25_4_SQ_60_2");
			dialog.HideNPC("CATACOMB_25_4_SQ_60_3");
			dialog.HideNPC("CATACOMB_25_4_SQ_60_4");
			await dialog.Msg("BalloonText/CATACOMB_25_4_SQ_60_SU2/7");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

