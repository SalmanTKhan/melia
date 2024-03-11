//--- Melia Script -----------------------------------------------------------
// You Can't Fool Me
//--- Description -----------------------------------------------------------
// Quest to Talk to Farm Supervisor Dorn.
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

[QuestScript(70021)]
public class Quest70021Script : QuestScript
{
	protected override void Load()
	{
		SetId(70021);
		SetName("You Can't Fool Me");
		SetDescription("Talk to Farm Supervisor Dorn");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ01"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_MQ_02_1", "FARM49_2_MQ02", "I will find it", "I don't want to be involved in this kind of matters"))
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

		if (character.Inventory.HasItem("FARM49_2_MQ02_ITEM", 8))
		{
			character.Inventory.RemoveItem("FARM49_2_MQ02_ITEM", 8);
			await dialog.Msg("FARM49_2_MQ_02_5");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

