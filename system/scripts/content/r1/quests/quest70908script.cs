//--- Melia Script -----------------------------------------------------------
// The trace of the final mission
//--- Description -----------------------------------------------------------
// Quest to Talk with Gasper.
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

[QuestScript(70908)]
public class Quest70908Script : QuestScript
{
	protected override void Load()
	{
		SetId(70908);
		SetName("The trace of the final mission");
		SetDescription("Talk with Gasper");

		AddPrerequisite(new LevelPrerequisite(303));

		AddReward(new ExpReward(12101740, 12101740));
		AddReward(new ItemReward("expCard13", 1));
		AddReward(new ItemReward("Vis", 13938));

		AddDialogHook("DCAPITAL103_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_09_start", "DCAPITAL103_SQ09", "How do I find them?", "It sounds far too complicated."))
		{
			case 1:
				await dialog.Msg("DCAPITAL103_SQ_09_agree");
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

		if (character.Inventory.HasItem("DCAPITAL103_SQ09_ITEM2", 5))
		{
			character.Inventory.RemoveItem("DCAPITAL103_SQ09_ITEM2", 5);
			await dialog.Msg("DCAPITAL103_SQ_09_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

