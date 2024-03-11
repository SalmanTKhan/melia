//--- Melia Script -----------------------------------------------------------
// Sword Pell Repair (2)
//--- Description -----------------------------------------------------------
// Quest to Repair the Sword Pell.
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

[QuestScript(50263)]
public class Quest50263Script : QuestScript
{
	protected override void Load()
	{
		SetId(50263);
		SetName("Sword Pell Repair (2)");
		SetDescription("Repair the Sword Pell");

		AddPrerequisite(new LevelPrerequisite(1));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI16_HQ1"));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("JOB_2_HIGHLANDER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("SIAULIAI16_HIDDENQ1_ITEM4", 1))
		{
			character.Inventory.RemoveItem("SIAULIAI16_HIDDENQ1_ITEM4", 1);
			await dialog.Msg("SIAULIAI16_HQ2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

