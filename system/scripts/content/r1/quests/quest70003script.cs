//--- Melia Script -----------------------------------------------------------
// Preparing for Large-Scale Purification
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Ellie.
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

[QuestScript(70003)]
public class Quest70003Script : QuestScript
{
	protected override void Load()
	{
		SetId(70003);
		SetName("Preparing for Large-Scale Purification");
		SetDescription("Talk to Druid Ellie");

		AddPrerequisite(new LevelPrerequisite(149));
		AddPrerequisite(new CompletedPrerequisite("FARM49_1_MQ03"));

		AddObjective("collect0", "Collect 20 Tama Body Fluid(s)", new CollectItemObjective("FARM49_1_MQ04_ITEM", 20));
		AddDrop("FARM49_1_MQ04_ITEM", 10f, "Tama_orange");

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_MQ_04_1", "FARM49_1_MQ04", "I will collect for her", "I can't help with that"))
		{
			case 1:
				await dialog.Msg("FARM49_1_MQ_04_2");
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

		if (character.Inventory.HasItem("FARM49_1_MQ04_ITEM", 20))
		{
			character.Inventory.RemoveItem("FARM49_1_MQ04_ITEM", 20);
			await dialog.Msg("FARM49_1_MQ_04_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

