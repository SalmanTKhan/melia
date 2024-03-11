//--- Melia Script -----------------------------------------------------------
// Burning Stones [Fletcher Advancement]
//--- Description -----------------------------------------------------------
// Quest to The Call of the Fletcher Master.
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

[QuestScript(8739)]
public class Quest8739Script : QuestScript
{
	protected override void Load()
	{
		SetId(8739);
		SetName("Burning Stones [Fletcher Advancement]");
		SetDescription("The Call of the Fletcher Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_FLETCHER5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("collect0", "Collect 1 Well-Burnable Firestone", new CollectItemObjective("JOB_FLETCHER5_1_ITEM", 1));
		AddDrop("JOB_FLETCHER5_1_ITEM", 10f, "boss_yonazolem_J1");

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FLETCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FLETCHER5_1_01", "JOB_FLETCHER5_1", "I will bring burnable woods", "I'd like to stop"))
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

		if (character.Inventory.HasItem("JOB_FLETCHER5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_FLETCHER5_1_ITEM", 1);
			await dialog.Msg("JOB_FLETCHER5_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

