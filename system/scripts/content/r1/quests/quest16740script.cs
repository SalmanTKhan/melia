//--- Melia Script -----------------------------------------------------------
// Medicing Made of Spring Light Grass
//--- Description -----------------------------------------------------------
// Quest to Talk to Pharmacist Tiana.
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

[QuestScript(16740)]
public class Quest16740Script : QuestScript
{
	protected override void Load()
	{
		SetId(16740);
		SetName("Medicing Made of Spring Light Grass");
		SetDescription("Talk to Pharmacist Tiana");

		AddPrerequisite(new LevelPrerequisite(169));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_SQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_1_SQ_05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_1_SQ_05_select", "SIAULIAI_46_1_SQ_05", "Don't worry, I'll get it", "Just ignore it"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_1_SQ_05_start_prog");
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

		if (character.Inventory.HasItem("SIAULIAI_46_1_SQ_05_ITEM02", 5))
		{
			character.Inventory.RemoveItem("SIAULIAI_46_1_SQ_05_ITEM02", 5);
			await dialog.Msg("SIAULIAI_46_1_SQ_05_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

