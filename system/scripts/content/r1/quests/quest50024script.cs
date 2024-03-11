//--- Melia Script -----------------------------------------------------------
// Unsatisfactory Crops (1)
//--- Description -----------------------------------------------------------
// Quest to Researcher Gareth.
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

[QuestScript(50024)]
public class Quest50024Script : QuestScript
{
	protected override void Load()
	{
		SetId(50024);
		SetName("Unsatisfactory Crops (1)");
		SetDescription("Researcher Gareth");

		AddPrerequisite(new LevelPrerequisite(70));

		AddObjective("collect0", "Collect 6 Tough Orange Sakmoli Stem(s)", new CollectItemObjective("SIAULIAI50_SAMPLE02", 6));
		AddDrop("SIAULIAI50_SAMPLE02", 6f, "Sakmoli_orange");

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("SIAULIAI_50_1_SQ_RESEARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_RESEARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_170_select01", "SIAULIAI_50_1_SQ_170", "I'll help", "About the settlement land", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_170_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_50_1_SQ_170_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("SIAULIAI50_SAMPLE02", 6))
		{
			character.Inventory.RemoveItem("SIAULIAI50_SAMPLE02", 6);
			await dialog.Msg("SIAULIAI_50_1_SQ_170_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

