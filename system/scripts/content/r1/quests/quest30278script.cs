//--- Melia Script -----------------------------------------------------------
// Finding a Cure for the Epidemic (4)
//--- Description -----------------------------------------------------------
// Quest to Collect Plant Samples at Nobreer Falls.
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

[QuestScript(30278)]
public class Quest30278Script : QuestScript
{
	protected override void Load()
	{
		SetId(30278);
		SetName("Finding a Cure for the Epidemic (4)");
		SetDescription("Collect Plant Samples at Nobreer Falls");

		AddPrerequisite(new LevelPrerequisite(322));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_4"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15134));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("WTREES_21_2_SQ_5_ITEM", 8))
		{
			character.Inventory.RemoveItem("WTREES_21_2_SQ_5_ITEM", 8);
			await dialog.Msg("WTREES_21_2_SQ_5_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

