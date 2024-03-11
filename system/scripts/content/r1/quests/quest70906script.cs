//--- Melia Script -----------------------------------------------------------
// Treasure Trove of Knowledge
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

[QuestScript(70906)]
public class Quest70906Script : QuestScript
{
	protected override void Load()
	{
		SetId(70906);
		SetName("Treasure Trove of Knowledge");
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

		switch (await dialog.Select("DCAPITAL103_SQ_07_start", "DCAPITAL103_SQ07", "Gathering books, right? No big task. I will do it.", "It's a bad habit to rely on others for all your trouble, mate."))
		{
			case 1:
				await dialog.Msg("DCAPITAL103_SQ_07_agree");
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

		if (character.Inventory.HasItem("DCAPITAL103_SQ07_ITEM", 8))
		{
			character.Inventory.RemoveItem("DCAPITAL103_SQ07_ITEM", 8);
			await dialog.Msg("DCAPITAL103_SQ_07_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

