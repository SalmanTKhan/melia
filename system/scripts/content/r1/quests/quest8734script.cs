//--- Melia Script -----------------------------------------------------------
// Supply the Trap Parts [Sapper Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Sapper Master.
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

[QuestScript(8734)]
public class Quest8734Script : QuestScript
{
	protected override void Load()
	{
		SetId(8734);
		SetName("Supply the Trap Parts [Sapper Advancement]");
		SetDescription("Call of the Sapper Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SAPPER5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Natural Agate Stone", new CollectItemObjective("JOB_SAPPER5_1_ITEM", 1));
		AddDrop("JOB_SAPPER5_1_ITEM", 10f, "boss_Rocktortuga_J1");

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SAPPER5_1_01", "JOB_SAPPER5_1", "I will find it", "I'll wait a little bit"))
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

		if (character.Inventory.HasItem("JOB_SAPPER5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_SAPPER5_1_ITEM", 1);
			await dialog.Msg("JOB_SAPPER5_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

