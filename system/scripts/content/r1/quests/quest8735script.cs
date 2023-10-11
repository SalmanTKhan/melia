//--- Melia Script -----------------------------------------------------------
// State of Laziness [Hunter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Hunter Master.
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

[QuestScript(8735)]
public class Quest8735Script : QuestScript
{
	protected override void Load()
	{
		SetId(8735);
		SetName("State of Laziness [Hunter Advancement]");
		SetDescription("Call of the Hunter Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Huge Fang", new CollectItemObjective("JOB_HUNTER5_1_ITEM", 1));
		AddDrop("JOB_HUNTER5_1_ITEM", 10f, "boss_Minotaurs_J1");

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HUNTER5_1_01", "JOB_HUNTER5_1", "I'll hunt the Minotaur", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_HUNTER5_1_AG");
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

		if (character.Inventory.HasItem("JOB_HUNTER5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_HUNTER5_1_ITEM", 1);
			await dialog.Msg("JOB_HUNTER5_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

