//--- Melia Script -----------------------------------------------------------
// A Story of Demons and Goddesses (2)
//--- Description -----------------------------------------------------------
// Quest to Find the Box Containing the Treaty Slate.
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

[QuestScript(30293)]
public class Quest30293Script : QuestScript
{
	protected override void Load()
	{
		SetId(30293);
		SetName("A Story of Demons and Goddesses (2)");
		SetDescription("Find the Box Containing the Treaty Slate");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_9"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15275));

		AddDialogHook("WTREES_21_1_NPC_1_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("WTREES_21_1_SQ_10_ITEM", 1))
		{
			character.Inventory.RemoveItem("WTREES_21_1_SQ_10_ITEM", 1);
			await dialog.Msg("WTREES_21_1_SQ_10_succ");
			// Func/SCR_WTREES_21_1_SQ_10_SUCC;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/SCR_WTREES_21_1_SQ_10_RUN;
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("WTREES_21_1_NPC_1_AFTER");
	}
}

