//--- Melia Script -----------------------------------------------------------
// Beware of small wounds
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Phylia.
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

[QuestScript(70501)]
public class Quest70501Script : QuestScript
{
	protected override void Load()
	{
		SetId(70501);
		SetName("Beware of small wounds");
		SetDescription("Talk to Pilgrim Phylia");

		AddPrerequisite(new LevelPrerequisite(258));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10320));

		AddDialogHook("PILGRIM411_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM411_SQ_02_start", "PILGRIM41_1_SQ02", "Ask how you can help", "Say that you think remaining calm would be better"))
		{
			case 1:
				await dialog.Msg("PILGRIM411_SQ_02_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_1_SQ02_ITEM", 10))
		{
			character.Inventory.RemoveItem("PILGRIM41_1_SQ02_ITEM", 10);
			await dialog.Msg("PILGRIM411_SQ_02_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

