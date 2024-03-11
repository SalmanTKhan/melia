//--- Melia Script -----------------------------------------------------------
// Shaman Doll [Bokor Advancement]
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

[QuestScript(8745)]
public class Quest8745Script : QuestScript
{
	protected override void Load()
	{
		SetId(8745);
		SetName("Shaman Doll [Bokor Advancement]");
		SetDescription("Talk to the Bokor Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_BOCOR5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Stone Whale Essence", new CollectItemObjective("JOB_BOCOR5_1_ITEM", 1));
		AddDrop("JOB_BOCOR5_1_ITEM", 10f, "boss_stone_whale");

		AddDialogHook("MASTER_BOCORS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_BOCOR5_1_01", "JOB_BOCOR5_1", "I will get the essence", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("JOB_BOCOR5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_BOCOR5_1_ITEM", 1);
			await dialog.Msg("JOB_BOCOR5_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

