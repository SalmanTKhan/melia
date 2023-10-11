//--- Melia Script -----------------------------------------------------------
// Let the Hunting Begin [Falconer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Falconer Master.
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

[QuestScript(90159)]
public class Quest90159Script : QuestScript
{
	protected override void Load()
	{
		SetId(90159);
		SetName("Let the Hunting Begin [Falconer Advancement]");
		SetDescription("Talk with the Falconer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_FALCONER_8_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("collect0", "Collect 1 Gosal Horn", new CollectItemObjective("JOB_FALCONER_8_1_ITEM", 1));
		AddDrop("JOB_FALCONER_8_1_ITEM", 10f, "boss_Gosal_J1");

		AddDialogHook("MASTER_FALCONER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FALCONER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FALCONER_8_1_ST", "JOB_FALCONER_8_1", "I am fully ready to go.", "Not now."))
		{
			case 1:
				await dialog.Msg("JOB_FALCONER_8_1_AG");
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

		if (character.Inventory.HasItem("JOB_FALCONER_8_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_FALCONER_8_1_ITEM", 1);
			await dialog.Msg("JOB_FALCONER_8_1_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

