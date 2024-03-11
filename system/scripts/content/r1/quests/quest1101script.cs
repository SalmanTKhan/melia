//--- Melia Script -----------------------------------------------------------
// Shield over Flowers [Highlander Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Highlander Master.
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

[QuestScript(1101)]
public class Quest1101Script : QuestScript
{
	protected override void Load()
	{
		SetId(1101);
		SetName("Shield over Flowers [Highlander Advancement] (1)");
		SetDescription("Talk to the Highlander Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 7 Coarse Bark(s)", new CollectItemObjective("WOODEN_SHIELD_PART", 7));
		AddDrop("WOODEN_SHIELD_PART", 10f, "Yognome");

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HIGHLANDER2_1_select1", "JOB_HIGHLANDER2_1", "What is the mission?", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_HIGHLANDER2_1_prog1");
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

		if (character.Inventory.HasItem("WOODEN_SHIELD_PART", 7))
		{
			character.Inventory.RemoveItem("WOODEN_SHIELD_PART", 7);
			await dialog.Msg("JOB_HIGHLANDER2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

