//--- Melia Script -----------------------------------------------------------
// Laima's Prophecy Tome (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lenja.
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

[QuestScript(30284)]
public class Quest30284Script : QuestScript
{
	protected override void Load()
	{
		SetId(30284);
		SetName("Laima's Prophecy Tome (1)");
		SetDescription("Talk to Kupole Lenja");

		AddPrerequisite(new LevelPrerequisite(325));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15275));

		AddDialogHook("WTREES_21_1_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_1_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_1_SQ_1_select", "WTREES_21_1_SQ_1", "I'll find the treaty.", "We should focus on the present instead of dwelling on the past."))
		{
			case 1:
				await dialog.Msg("WTREES_21_1_SQ_1_agree");
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

		if (character.Inventory.HasItem("WTREES_21_1_SQ_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("WTREES_21_1_SQ_1_ITEM", 1);
			await dialog.Msg("WTREES_21_1_SQ_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

