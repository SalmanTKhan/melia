//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Motimer..
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

[QuestScript(91011)]
public class Quest91011Script : QuestScript
{
	protected override void Load()
	{
		SetId(91011);
		SetName("White Witch and the Crusader(4)");
		SetDescription("Talk to Soldier Motimer.");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_04"));

		AddObjective("collect0", "Collect 1 Worn out Shackle", new CollectItemObjective("F_TABLELAND_28_2_RAID_05_ITEM", 1));
		AddDrop("F_TABLELAND_28_2_RAID_05_ITEM", 5f, 57941, 57899, 57900);

		AddReward(new ItemReward("expCard17", 2));
		AddReward(new ItemReward("Vis", 26840));

		AddDialogHook("TABLELAND282_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG17", "F_TABLELAND_28_2_RAID_05", "Tell him you will go there", "I am not interested."))
		{
			case 1:
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG18");
				dialog.UnHideNPC("F_TABLELAND_28_2_RAID_05_NPC_01");
				dialog.UnHideNPC("F_TABLELAND_28_2_RAID_05_NPC_00");
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
			await dialog.Msg("F_TABLELAND_28_2_RAID_DLG20");
			dialog.HideNPC("F_TABLELAND_28_2_RAID_05_NPC_01");
			dialog.HideNPC("F_TABLELAND_28_2_RAID_05_NPC_02");
			dialog.HideNPC("F_TABLELAND_28_2_RAID_05_NPC_03");
			dialog.HideNPC("F_TABLELAND_28_2_RAID_05_NPC_04");
			dialog.HideNPC("F_TABLELAND_28_2_RAID_05_NPC_00");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

