//--- Melia Script -----------------------------------------------------------
// Summoning Ritual [Necromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Necromancer Master.
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

[QuestScript(17680)]
public class Quest17680Script : QuestScript
{
	protected override void Load()
	{
		SetId(17680);
		SetName("Summoning Ritual [Necromancer Advancement]");
		SetDescription("Talk to the Necromancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_NECROMANCER4_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("collect0", "Collect 7 Blue Pawndel Bones(s)", new CollectItemObjective("JOB_NECROMANCER4_1_ITEM1", 7));
		AddObjective("collect1", "Collect 3 Black Pawnd's Entrails(s)", new CollectItemObjective("JOB_NECROMANCER4_1_ITEM2", 3));
		AddObjective("collect2", "Collect 1 Harpeia's Beak", new CollectItemObjective("JOB_NECROMANCER4_1_ITEM3", 1));
		AddDrop("JOB_NECROMANCER4_1_ITEM1", 10f, "Pawndel_blue");
		AddDrop("JOB_NECROMANCER4_1_ITEM2", 10f, "Pawnd_purple");
		AddDrop("JOB_NECROMANCER4_1_ITEM3", 10f, "boss_Harpeia_J1");

		AddDialogHook("JOB_NECRO4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_NECRO4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_NECROMANCER4_1_ST", "JOB_NECROMANCER5_1", "Ask what the gift is", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_NECROMANCER4_1_AG");
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

		if (character.Inventory.HasItem("JOB_NECROMANCER4_1_ITEM1", 7) && character.Inventory.HasItem("JOB_NECROMANCER4_1_ITEM2", 3) && character.Inventory.HasItem("JOB_NECROMANCER4_1_ITEM3", 1))
		{
			character.Inventory.RemoveItem("JOB_NECROMANCER4_1_ITEM1", 7);
			character.Inventory.RemoveItem("JOB_NECROMANCER4_1_ITEM2", 3);
			character.Inventory.RemoveItem("JOB_NECROMANCER4_1_ITEM3", 1);
			await dialog.Msg("JOB_NECROMANCER4_1_COMP");
			dialog.ShowHelp("TUTO_CLASS_NECROMANCER");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

