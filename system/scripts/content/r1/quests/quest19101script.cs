//--- Melia Script -----------------------------------------------------------
// Positive of curiosity
//--- Description -----------------------------------------------------------
// Quest to Talk to the gatekeeper owl.
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

[QuestScript(19101)]
public class Quest19101Script : QuestScript
{
	protected override void Load()
	{
		SetId(19101);
		SetName("Positive of curiosity");
		SetDescription("Talk to the gatekeeper owl");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 100 Great Cathedral Marble Parts(s)", new CollectItemObjective("KATYN_10_HQ_01_ITEM1", 100));
		AddDrop("KATYN_10_HQ_01_ITEM1", 3f, "Moya");

		AddDialogHook("KATYN10_SCRTOR6_OWL01", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_10_HQ_01_ST", "KATYN_10_HQ_01", "I'll do it", "Decline"))
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

		if (character.Inventory.HasItem("KATYN_10_HQ_01_ITEM1", 100))
		{
			character.Inventory.RemoveItem("KATYN_10_HQ_01_ITEM1", 100);
			await dialog.Msg("KATYN_10_HQ_01_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

