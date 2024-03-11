//--- Melia Script -----------------------------------------------------------
// An Endless Mission (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Commander Wallace.
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

[QuestScript(4402)]
public class Quest4402Script : QuestScript
{
	protected override void Load()
	{
		SetId(4402);
		SetName("An Endless Mission (4)");
		SetDescription("Talk to Commander Wallace");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_10"));

		AddObjective("collect0", "Collect 10 Cronewt Leather(s)", new CollectItemObjective("THORN23_Mushroom_1", 10));
		AddDrop("THORN23_Mushroom_1", 10f, "Cronewt");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_WALLACE", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_WALLACE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN23_Q_12_select1", "THORN23_Q_12", "Collect Cronewt leathers", "I'm not a new recruit"))
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

		if (character.Inventory.HasItem("THORN23_Mushroom_1", 10))
		{
			character.Inventory.RemoveItem("THORN23_Mushroom_1", 10);
			await dialog.Msg("THORN23_Q_12_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

