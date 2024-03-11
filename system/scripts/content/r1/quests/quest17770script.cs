//--- Melia Script -----------------------------------------------------------
// Honor of the Legwyn Family [Squire Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Squire Master.
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

[QuestScript(17770)]
public class Quest17770Script : QuestScript
{
	protected override void Load()
	{
		SetId(17770);
		SetName("Honor of the Legwyn Family [Squire Advancement]");
		SetDescription("Talk to the Squire Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_BARBARIAN5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("collect0", "Collect 1 Legwyn Family Decoration", new CollectItemObjective("JOB_SQUIRE5_1_ITEM", 1));
		AddDrop("JOB_SQUIRE5_1_ITEM", 10f, "boss_poata_J1");

		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SQUIRE5_1_select", "JOB_SQUIRE5_1", "I'll help you find the decorations", "I will come back later"))
		{
			case 1:
				await dialog.Msg("JOB_SQUIRE5_1_AG");
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

		if (character.Inventory.HasItem("JOB_SQUIRE5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_SQUIRE5_1_ITEM", 1);
			await dialog.Msg("JOB_SQUIRE5_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

