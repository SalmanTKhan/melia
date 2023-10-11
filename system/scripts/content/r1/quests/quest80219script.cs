//--- Melia Script -----------------------------------------------------------
// We're Being Watched (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Jones.
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

[QuestScript(80219)]
public class Quest80219Script : QuestScript
{
	protected override void Load()
	{
		SetId(80219);
		SetName("We're Being Watched (1)");
		SetDescription("Talk to Monk Jones");

		AddPrerequisite(new LevelPrerequisite(179));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_SQ05_select01", "THORN39_3_SQ05", "Leave it to me", "It's probably just a feeling."))
		{
			case 1:
				await dialog.Msg("THORN39_3_SQ05_agree01");
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

		if (character.Inventory.HasItem("THORN39_3_SQ05_ITEM", 7))
		{
			character.Inventory.RemoveItem("THORN39_3_SQ05_ITEM", 7);
			await dialog.Msg("THORN39_3_SQ05_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN39_3_SQ06");
	}
}

