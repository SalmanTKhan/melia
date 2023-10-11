//--- Melia Script -----------------------------------------------------------
// Time Stops Along With the Season (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Ida.
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

[QuestScript(90114)]
public class Quest90114Script : QuestScript
{
	protected override void Load()
	{
		SetId(90114);
		SetName("Time Stops Along With the Season (1)");
		SetDescription("Talk to Chronomancer Ida");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_1_SQ_20"), new CompletedPrerequisite("MAPLE_25_1_SQ_40"), new CompletedPrerequisite("MAPLE_25_1_SQ_60"));
		AddPrerequisite(new ItemPrerequisite("MAPLE_25_1_SQ_ITEM1", -100), new ItemPrerequisite("MAPLE_25_1_SQ_ITEM2", -100), new ItemPrerequisite("MAPLE_25_1_SQ_ITEM3", -100));

		AddObjective("collect0", "Collect 8 Blood Sample(s)", new CollectItemObjective("MAPLE_25_1_SQ_70_ITEM", 8));
		AddDrop("MAPLE_25_1_SQ_70_ITEM", 9f, 58539, 58540, 58538);

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("MAPLE_25_1_AIDAS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_AIDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_70_ST", "MAPLE_25_1_SQ_70", "Of course, I will help.", "I am not interested"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_70_AG");
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

		if (character.Inventory.HasItem("MAPLE_25_1_SQ_70_ITEM", 8))
		{
			character.Inventory.RemoveItem("MAPLE_25_1_SQ_70_ITEM", 8);
			await dialog.Msg("MAPLE_25_1_SQ_70_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

