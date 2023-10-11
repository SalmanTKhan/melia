//--- Melia Script -----------------------------------------------------------
// Preventive Measures (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tara Miles.
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

[QuestScript(8462)]
public class Quest8462Script : QuestScript
{
	protected override void Load()
	{
		SetId(8462);
		SetName("Preventive Measures (2)");
		SetDescription("Talk to Tara Miles");

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("REMAINS40_SQ_03"));

		AddObjective("collect0", "Collect 7 Dust Sample(s)", new CollectItemObjective("REMAINS40_SQ_04_ITEM", 7));
		AddDrop("REMAINS40_SQ_04_ITEM", 10f, "Hallowventor");

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_TARA_02", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_TARA_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_SQ_04_01", "REMAINS40_SQ_04", "I'll gather the sample first.", "I'd like to stop"))
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

		if (character.Inventory.HasItem("REMAINS40_SQ_04_ITEM", 7))
		{
			character.Inventory.RemoveItem("REMAINS40_SQ_04_ITEM", 7);
			await dialog.Msg("REMAINS40_SQ_04_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

