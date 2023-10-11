//--- Melia Script -----------------------------------------------------------
// Borrowing Old Equipment
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70562)]
public class Quest70562Script : QuestScript
{
	protected override void Load()
	{
		SetId(70562);
		SetName("Borrowing Old Equipment");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(268));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ02"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10988));

		AddDialogHook("PILGRIM413_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM413_SQ_03_start", "PILGRIM41_3_SQ03", "How can I help you?", "Ask if she isn't mistaken"))
		{
			case 1:
				await dialog.Msg("PILGRIM413_SQ_03_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_3_SQ03_ITEM", 1))
		{
			character.Inventory.RemoveItem("PILGRIM41_3_SQ03_ITEM", 1);
			await dialog.Msg("PILGRIM413_SQ_03_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

