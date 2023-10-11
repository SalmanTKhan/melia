//--- Melia Script -----------------------------------------------------------
// Prepare a solid meal
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Brad.
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

[QuestScript(70505)]
public class Quest70505Script : QuestScript
{
	protected override void Load()
	{
		SetId(70505);
		SetName("Prepare a solid meal");
		SetDescription("Talk to Pilgrim Brad");

		AddPrerequisite(new LevelPrerequisite(258));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_1_SQ05"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10320));

		AddDialogHook("PILGRIM411_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM411_SQ_06_start", "PILGRIM41_1_SQ06", "Ask what type of meat you should gather", "Say that there is no way to get meat here"))
		{
			case 1:
				await dialog.Msg("PILGRIM411_SQ_06_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_1_SQ06_ITEM", 15))
		{
			character.Inventory.RemoveItem("PILGRIM41_1_SQ06_ITEM", 15);
			await dialog.Msg("PILGRIM411_SQ_06_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

