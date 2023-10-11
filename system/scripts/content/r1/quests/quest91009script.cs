//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Plague Doctor again..
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

[QuestScript(91009)]
public class Quest91009Script : QuestScript
{
	protected override void Load()
	{
		SetId(91009);
		SetName("White Witch and the Crusader(2)");
		SetDescription("Talk to the Plague Doctor again.");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_02"));

		AddDialogHook("PLAGUEDOCTOR_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_CRUSADER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG09", "F_TABLELAND_28_2_RAID_03", "I'll do my best on this task.", "I want to quit."))
		{
			case 1:
				// Func/SCR_PLAGUEDOCTOR_MASTER_REGIVE/0;
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

		if (character.Inventory.HasItem("SNOW_RAID_Q_ITEM_02", 1))
		{
			character.Inventory.RemoveItem("SNOW_RAID_Q_ITEM_02", 1);
			await dialog.Msg("F_TABLELAND_28_2_RAID_DLG10");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

