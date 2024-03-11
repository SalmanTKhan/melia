//--- Melia Script -----------------------------------------------------------
// Blitz [Monk Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Monk Master.
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

[QuestScript(8749)]
public class Quest8749Script : QuestScript
{
	protected override void Load()
	{
		SetId(8749);
		SetName("Blitz [Monk Advancement]");
		SetDescription("Talk to the Monk Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_THAUELE5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("collect0", "Collect 1 Sharp Canine", new CollectItemObjective("JOB_MONK5_1_ITEM", 1));
		AddDrop("JOB_MONK5_1_ITEM", 10f, "boss_NetherBovine_J1");

		AddDialogHook("JOB_MONK4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_MONK4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_MONK5_1_01", "JOB_MONK5_1", "I'll bring the evidence", "Decline"))
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

		if (character.Inventory.HasItem("JOB_MONK5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_MONK5_1_ITEM", 1);
			await dialog.Msg("JOB_MONK5_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

