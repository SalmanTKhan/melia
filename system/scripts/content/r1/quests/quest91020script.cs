//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(12)
//--- Description -----------------------------------------------------------
// Quest to Talk to Rangda Master..
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

[QuestScript(91020)]
public class Quest91020Script : QuestScript
{
	protected override void Load()
	{
		SetId(91020);
		SetName("White Witch and the Crusader(12)");
		SetDescription("Talk to Rangda Master.");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_12"));

		AddDialogHook("MASTER_RANGDA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_RANGDAGIRL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG43", "F_TABLELAND_28_2_RAID_13", "Alright", "I don't want to be involved anymore."))
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

		if (character.Inventory.HasItem("F_TABLELAND_28_2_RAID_13_ITEM", 1))
		{
			character.Inventory.RemoveItem("F_TABLELAND_28_2_RAID_13_ITEM", 1);
			await dialog.Msg("F_TABLELAND_28_2_RAID_DLG44");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

