//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Crusader Envoy.
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

[QuestScript(91008)]
public class Quest91008Script : QuestScript
{
	protected override void Load()
	{
		SetId(91008);
		SetName("White Witch and the Crusader(1)");
		SetDescription("Talk to Crusader Envoy");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_01"));

		AddReward(new ItemReward("expCard17", 1));
		AddReward(new ItemReward("Vis", 26840));

		AddDialogHook("NPC_CRUSADER_01", "BeforeStart", BeforeStart);
		AddDialogHook("PLAGUEDOCTOR_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG04", "F_TABLELAND_28_2_RAID_02", "Tell him you will go there", "I am busy with other things right now."))
		{
			case 1:
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG05");
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
			await dialog.Msg("F_TABLELAND_28_2_RAID_DLG08");
			dialog.HideNPC("F_TABLELAND_28_2_RAID_02_NPC_01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

