//--- Melia Script -----------------------------------------------------------
// Angry Bees (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Raeli.
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

[QuestScript(50286)]
public class Quest50286Script : QuestScript
{
	protected override void Load()
	{
		SetId(50286);
		SetName("Angry Bees (1)");
		SetDescription("Talk with Priest Raeli");

		AddPrerequisite(new LevelPrerequisite(166));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_1_MQ_05"));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI462_HQ1_start1", "SIAULIAI462_HQ1", "How can we make the bees calm down?", "That doesn't sound like much of a problem."))
		{
			case 1:
				await dialog.Msg("SIAULIAI462_HQ1_agree1");
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

		if (character.Inventory.HasItem("SIAULIAI462_HIDDENQ1_ITEM1", 10) && character.Inventory.HasItem("SIAULIAI462_HIDDENQ1_ITEM2", 6))
		{
			character.Inventory.RemoveItem("SIAULIAI462_HIDDENQ1_ITEM1", 10);
			character.Inventory.RemoveItem("SIAULIAI462_HIDDENQ1_ITEM2", 6);
			await dialog.Msg("SIAULIAI462_HQ1_succ3");
			// Func/SIAULIAI462_HIDDENQ1_COMP;
			await dialog.Msg("BalloonText/SIAULIAI462_HQ1_INFOR1/3");
			await dialog.Msg("FadeOutIN/1500");
			await dialog.Msg("SIAULIAI462_HQ1_succ2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

