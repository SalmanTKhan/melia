//--- Melia Script -----------------------------------------------------------
// According To One's Duty
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Audra.
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

[QuestScript(60030)]
public class Quest60030Script : QuestScript
{
	protected override void Load()
	{
		SetId(60030);
		SetName("According To One's Duty");
		SetDescription("Talk to Kupole Audra");

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_05"));

		AddObjective("collect0", "Collect 8 Expedition Memento(s)", new CollectItemObjective("VPRISON511_SQ_02_ITEM", 8));
		AddDrop("VPRISON511_SQ_02_ITEM", 10f, 57316, 57315, 57313, 57319);

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 4379));

		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_SQ_02_01", "VPRISON511_SQ_02", "I will look for keepsakes", "Tell her that there is a more emergent issue"))
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

		if (character.Inventory.HasItem("VPRISON511_SQ_02_ITEM", 8))
		{
			character.Inventory.RemoveItem("VPRISON511_SQ_02_ITEM", 8);
			await dialog.Msg("VPRISON511_SQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

