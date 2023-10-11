//--- Melia Script -----------------------------------------------------------
// Do Not Sully The Keepsakes
//--- Description -----------------------------------------------------------
// Quest to Talk with Gasper.
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

[QuestScript(70907)]
public class Quest70907Script : QuestScript
{
	protected override void Load()
	{
		SetId(70907);
		SetName("Do Not Sully The Keepsakes");
		SetDescription("Talk with Gasper");

		AddPrerequisite(new LevelPrerequisite(303));

		AddObjective("collect0", "Collect 13 Advance Party's Keepsakes(s)", new CollectItemObjective("DCAPITAL103_SQ08_ITEM", 13));
		AddDrop("DCAPITAL103_SQ08_ITEM", 8f, 58493, 58494);

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

		switch (await dialog.Select("DCAPITAL103_SQ_08_start", "DCAPITAL103_SQ08", "That looks like a job for me.", "Green goblin? Now that's the name you should run away from."))
		{
			case 1:
				await dialog.Msg("DCAPITAL103_SQ_08_agree");
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

		if (character.Inventory.HasItem("DCAPITAL103_SQ08_ITEM", 13))
		{
			character.Inventory.RemoveItem("DCAPITAL103_SQ08_ITEM", 13);
			await dialog.Msg("DCAPITAL103_SQ_08_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

