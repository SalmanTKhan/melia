//--- Melia Script -----------------------------------------------------------
// To the Storage Quarter (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Manager.
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

[QuestScript(50067)]
public class Quest50067Script : QuestScript
{
	protected override void Load()
	{
		SetId(50067);
		SetName("To the Storage Quarter (1)");
		SetDescription("Talk to the Old Manager");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_67_MQ040"));

		AddObjective("collect0", "Collect 3 Earth Crystal(s)", new CollectItemObjective("UNDER67_MQ5_ITEM01", 3));
		AddDrop("UNDER67_MQ5_ITEM01", 10f, "dandel_white");

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("UNDER67_MQ5_ITEM02", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("EMINENT_67_1", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_67_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_67_MQ050_startnpc01", "UNDERFORTRESS_67_MQ050", "I will acquire the Earth Crystal", "I will obtain them later"))
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

		if (character.Inventory.HasItem("UNDER67_MQ5_ITEM01", 3))
		{
			character.Inventory.RemoveItem("UNDER67_MQ5_ITEM01", 3);
			await dialog.Msg("UNDER_67_MQ050_succ03");
			// Func/UNDER67_MQ05_MAKING;
			await dialog.Msg("UNDER_67_MQ050_succ02");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

