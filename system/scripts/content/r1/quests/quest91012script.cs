//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(5)
//--- Description -----------------------------------------------------------
// Quest to Hand over worn out shackle to Crusader Envoy.
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

[QuestScript(91012)]
public class Quest91012Script : QuestScript
{
	protected override void Load()
	{
		SetId(91012);
		SetName("White Witch and the Crusader(5)");
		SetDescription("Hand over worn out shackle to Crusader Envoy");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_05"));

		AddDialogHook("NPC_CRUSADER_01", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_CRUSADER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG21", "F_TABLELAND_28_2_RAID_06", "Share the result of the investigation.", "The investigation is not finished yet."))
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

		if (character.Inventory.HasItem("F_TABLELAND_28_2_RAID_05_ITEM", 1))
		{
			character.Inventory.RemoveItem("F_TABLELAND_28_2_RAID_05_ITEM", 1);
			await dialog.Msg("F_TABLELAND_28_2_RAID_DLG22");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

