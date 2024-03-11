//--- Melia Script -----------------------------------------------------------
// Price for the Lost Indulgence [Pardoner Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pardoner Master.
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

[QuestScript(8750)]
public class Quest8750Script : QuestScript
{
	protected override void Load()
	{
		SetId(8750);
		SetName("Price for the Lost Indulgence [Pardoner Advancement]");
		SetDescription("Talk to the Pardoner Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_FLETCHER5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("collect0", "Collect 1 Lost Indulgence Offering", new CollectItemObjective("JOB_PARDONER5_1_ITEM", 1));
		AddDrop("JOB_PARDONER5_1_ITEM", 10f, "boss_yonazolem_J1");

		AddDialogHook("JOB_PARDONER4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_PARDONER4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PARDONER5_1_01", "JOB_PARDONER5_1", "I'll get you the payment", "Decline"))
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

		if (character.Inventory.HasItem("JOB_PARDONER5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_PARDONER5_1_ITEM", 1);
			await dialog.Msg("JOB_PARDONER5_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

