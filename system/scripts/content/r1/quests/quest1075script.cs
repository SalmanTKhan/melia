//--- Melia Script -----------------------------------------------------------
// Bothersome Mission [Psychokino Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Psychokino Submaster.
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

[QuestScript(1075)]
public class Quest1075Script : QuestScript
{
	protected override void Load()
	{
		SetId(1075);
		SetName("Bothersome Mission [Psychokino Advancement]");
		SetDescription("Talk to the Psychokino Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 7 Desmodus' Tail Pin(s)", new CollectItemObjective("JOB_PSYCHOKINESIST2_1_ITEM1", 7));
		AddDrop("JOB_PSYCHOKINESIST2_1_ITEM1", 10f, "New_desmodus");

		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PSYCHOKINESIST2_1_select1", "JOB_PSYCHOKINESIST2_1", "I'll be the assistant", "I don't need it"))
		{
			case 1:
				await dialog.Msg("JOB_PSYCHOKINESIST2_1_agree1");
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

		if (character.Inventory.HasItem("JOB_PSYCHOKINESIST2_1_ITEM1", 7))
		{
			character.Inventory.RemoveItem("JOB_PSYCHOKINESIST2_1_ITEM1", 7);
			await dialog.Msg("JOB_PSYCHOKINESIST2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

