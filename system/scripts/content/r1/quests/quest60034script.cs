//--- Melia Script -----------------------------------------------------------
// Dionys' Claws
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Aldona.
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

[QuestScript(60034)]
public class Quest60034Script : QuestScript
{
	protected override void Load()
	{
		SetId(60034);
		SetName("Dionys' Claws");
		SetDescription("Talk to Kupole Aldona");

		AddPrerequisite(new LevelPrerequisite(157));
		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_06"));

		AddObjective("collect0", "Collect 9 Dionys' Claws(s)", new CollectItemObjective("VPRISON514_SQ_02_ITEM", 9));
		AddDrop("VPRISON514_SQ_02_ITEM", 10f, 57691, 57689, 57449, 400463);

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4553));

		AddDialogHook("VPRISON514_MQ_ALDONA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_ALDONA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON514_SQ_02_01", "VPRISON514_SQ_02", "I will retrieve the claws", "About Dionys", "It said to be it's not enough to cheer up."))
		{
			case 1:
				await dialog.Msg("VPRISON514_SQ_02_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("VPRISON514_SQ_02_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("VPRISON514_SQ_02_ITEM", 9))
		{
			character.Inventory.RemoveItem("VPRISON514_SQ_02_ITEM", 9);
			await dialog.Msg("VPRISON514_SQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

