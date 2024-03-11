//--- Melia Script -----------------------------------------------------------
// Hidden Seeds
//--- Description -----------------------------------------------------------
// Quest to Talk to Tenant Weiss.
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

[QuestScript(70032)]
public class Quest70032Script : QuestScript
{
	protected override void Load()
	{
		SetId(70032);
		SetName("Hidden Seeds");
		SetDescription("Talk to Tenant Weiss");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_SQ05"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_SQ_06_1", "FARM49_2_SQ06", "I will find the seeds for him", "Decline"))
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

		if (character.Inventory.HasItem("FARM49_2_SQ06_ITEM", 1))
		{
			character.Inventory.RemoveItem("FARM49_2_SQ06_ITEM", 1);
			await dialog.Msg("FARM49_2_SQ_06_5");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

