//--- Melia Script -----------------------------------------------------------
// Unfinished Commission (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Laudi.
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

[QuestScript(19320)]
public class Quest19320Script : QuestScript
{
	protected override void Load()
	{
		SetId(19320);
		SetName("Unfinished Commission (3)");
		SetDescription("Talk to Archaeologist Laudi");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_QUEST02"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_REXIPHER1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_REXIPHER1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_QUEST02_AFTER_ST", "ROKAS26_QUEST02_AFTER", "I'll find the artifact", "I'll stop now. It's annoying."))
		{
			case 1:
				await dialog.Msg("ROKAS26_QUEST02_AFTER_AC");
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

		if (character.Inventory.HasItem("ROKAS26_M_SLATE2", 3) && character.Inventory.HasItem("ROKAS26_M_SLATE3", 1) && character.Inventory.HasItem("ROKAS26_M_SLATE4", 1))
		{
			character.Inventory.RemoveItem("ROKAS26_M_SLATE2", 3);
			character.Inventory.RemoveItem("ROKAS26_M_SLATE3", 1);
			character.Inventory.RemoveItem("ROKAS26_M_SLATE4", 1);
			await dialog.Msg("ROKAS26_QUEST05_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

