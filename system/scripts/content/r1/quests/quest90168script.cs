//--- Melia Script -----------------------------------------------------------
// Interview - Fencer Master (2)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Old Diary.
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

[QuestScript(90168)]
public class Quest90168Script : QuestScript
{
	protected override void Load()
	{
		SetId(90168);
		SetName("Interview - Fencer Master (2)");
		SetDescription("Inspect the Old Diary");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LOWLV_MASTER_SQ_40_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_MASTER_ENCY_SQ_30"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("LOWLV_MASTER_ENCY_SQ_40_ITEM", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("LOWLV_MASTER_ENCY_SQ_30_BOOK", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FENCER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_MASTER_ENCY_SQ_40_ST", "LOWLV_MASTER_ENCY_SQ_40"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("LOWLV_MASTER_ENCY_SQ_40_ITEM2", 1))
		{
			character.Inventory.RemoveItem("LOWLV_MASTER_ENCY_SQ_40_ITEM2", 1);
			await dialog.Msg("LOWLV_MASTER_ENCY_SQ_40_SU");
			dialog.HideNPC("LOWLV_MASTER_ENCY_SQ_30_BOOK");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

