//--- Melia Script -----------------------------------------------------------
// Stolen Parchment
//--- Description -----------------------------------------------------------
// Quest to Talk with Investigation Team Head Ella.
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

[QuestScript(70901)]
public class Quest70901Script : QuestScript
{
	protected override void Load()
	{
		SetId(70901);
		SetName("Stolen Parchment");
		SetDescription("Talk with Investigation Team Head Ella");

		AddPrerequisite(new LevelPrerequisite(303));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL103_SQ01"));

		AddReward(new ExpReward(12101740, 12101740));
		AddReward(new ItemReward("expCard13", 1));
		AddReward(new ItemReward("Vis", 13938));

		AddDialogHook("DCAPITAL103_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_02_start", "DCAPITAL103_SQ02", "Alright", "I have a very traumatic experience with goblins. So I'd rather not."))
		{
			case 1:
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

		if (character.Inventory.HasItem("DCAPITAL103_SQ01_ITEM", 9))
		{
			character.Inventory.RemoveItem("DCAPITAL103_SQ01_ITEM", 9);
			await dialog.Msg("DCAPITAL103_SQ_02_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

