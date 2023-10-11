//--- Melia Script -----------------------------------------------------------
// For Continuing Research
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80075)]
public class Quest80075Script : QuestScript
{
	protected override void Load()
	{
		SetId(80075);
		SetName("For Continuing Research");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_10"));

		AddObjective("collect0", "Collect 12 Spion Teeth(s)", new CollectItemObjective("SIAULIAI_35_1_SQ_11_TOOTH", 12));
		AddDrop("SIAULIAI_35_1_SQ_11_TOOTH", 10f, 57910, 57912, 57913);

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_35_1_SQ_11_start", "SIAULIAI_35_1_SQ_11", "I'll get it", "I'm busy now"))
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

		if (character.Inventory.HasItem("SIAULIAI_35_1_SQ_11_TOOTH", 12))
		{
			character.Inventory.RemoveItem("SIAULIAI_35_1_SQ_11_TOOTH", 12);
			await dialog.Msg("SIAULIAI_35_1_SQ_11_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

