//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Lintas.
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

[QuestScript(50222)]
public class Quest50222Script : QuestScript
{
	protected override void Load()
	{
		SetId(50222);
		SetName("Maven's Wishes(1)");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new LevelPrerequisite(316));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ1_START1", "BRACKEN43_4_SQ1", "I will help the task", "Leave your spot"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_4_SQ1_AGREE1");
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

		if (character.Inventory.HasItem("BRACKEN434_SUBQ1_ITEM", 9))
		{
			character.Inventory.RemoveItem("BRACKEN434_SUBQ1_ITEM", 9);
			await dialog.Msg("BRACKEN43_4_SQ1_SUCC1");
			dialog.HideNPC("BRACKEN434_SUBQ1_PAPER_NPC");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

