//--- Melia Script -----------------------------------------------------------
// Hard Work does not Betray [Wizard Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wizard Master.
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

[QuestScript(1113)]
public class Quest1113Script : QuestScript
{
	protected override void Load()
	{
		SetId(1113);
		SetName("Hard Work does not Betray [Wizard Advancement] (1)");
		SetDescription("Talk to the Wizard Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Glizardon Horn", new CollectItemObjective("JOB_WIZARD2_1_ITEM1", 1));
		AddObjective("collect1", "Collect 1 Galok Fur", new CollectItemObjective("JOB_WIZARD2_1_ITEM2", 1));
		AddObjective("collect2", "Collect 6 Egnome Fragment(s)", new CollectItemObjective("JOB_WIZARD2_1_ITEM3", 6));
		AddDrop("JOB_WIZARD2_1_ITEM1", 10f, "Glizardon");
		AddDrop("JOB_WIZARD2_1_ITEM2", 10f, "Galok");
		AddDrop("JOB_WIZARD2_1_ITEM3", 10f, "Egnome");

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WIZARD2_1_select1", "JOB_WIZARD2_1", "I'll help with the research", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_WIZARD2_1_agree1");
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

		if (character.Inventory.HasItem("JOB_WIZARD2_1_ITEM1", 1) && character.Inventory.HasItem("JOB_WIZARD2_1_ITEM2", 1) && character.Inventory.HasItem("JOB_WIZARD2_1_ITEM3", 6))
		{
			character.Inventory.RemoveItem("JOB_WIZARD2_1_ITEM1", 1);
			character.Inventory.RemoveItem("JOB_WIZARD2_1_ITEM2", 1);
			character.Inventory.RemoveItem("JOB_WIZARD2_1_ITEM3", 6);
			await dialog.Msg("JOB_WIZARD2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_WIZARD2_2");
	}
}

