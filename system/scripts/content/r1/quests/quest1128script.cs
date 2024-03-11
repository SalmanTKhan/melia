//--- Melia Script -----------------------------------------------------------
// Charm of a Bokor [Bokor Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Bokor Master.
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

[QuestScript(1128)]
public class Quest1128Script : QuestScript
{
	protected override void Load()
	{
		SetId(1128);
		SetName("Charm of a Bokor [Bokor Advancement]");
		SetDescription("Talk to the Bokor Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("collect0", "Collect 35 Monster Blood(s)", new CollectItemObjective("JOB_BOKOR3_ITEM1", 35));
		AddDrop("JOB_BOKOR3_ITEM1", 9f, 41435, 47309, 57603);

		AddDialogHook("MASTER_BOCORS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_BOKOR3_1_select1", "JOB_BOKOR3_1", "Go and gather monster's blood", "Decline"))
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

		if (character.Inventory.HasItem("JOB_BOKOR3_ITEM1", 35))
		{
			character.Inventory.RemoveItem("JOB_BOKOR3_ITEM1", 35);
			await dialog.Msg("JOB_BOKOR3_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

