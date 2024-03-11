//--- Melia Script -----------------------------------------------------------
// The Only Method
//--- Description -----------------------------------------------------------
// Quest to Talk to Justas.
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

[QuestScript(40680)]
public class Quest40680Script : QuestScript
{
	protected override void Load()
	{
		SetId(40680);
		SetName("The Only Method");
		SetDescription("Talk to Justas");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_010"));

		AddObjective("collect0", "Collect 9 Bone Fragments(s)", new CollectItemObjective("REMAINS37_3_SQ_020__ITEM_1", 9));
		AddDrop("REMAINS37_3_SQ_020__ITEM_1", 10f, "Hallowventor_bow");

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_020_ST", "REMAINS37_3_SQ_020", "I'll help you", "About the research", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS37_3_SQ_020_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAINS37_3_SQ_020_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("REMAINS37_3_SQ_020__ITEM_1", 9))
		{
			character.Inventory.RemoveItem("REMAINS37_3_SQ_020__ITEM_1", 9);
			await dialog.Msg("REMAINS37_3_SQ_020_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

