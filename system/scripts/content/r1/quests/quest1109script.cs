//--- Melia Script -----------------------------------------------------------
// Legend of the Cold Iron [Cryomancer Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Ask the Miners' Village Mayor about the whereabouts of the book.
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

[QuestScript(1109)]
public class Quest1109Script : QuestScript
{
	protected override void Load()
	{
		SetId(1109);
		SetName("Legend of the Cold Iron [Cryomancer Advancement] (2)");
		SetDescription("Ask the Miners' Village Mayor about the whereabouts of the book");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER2_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_CRYOMANCER2_1"));

		AddObjective("collect0", "Collect 1 Armor from the Kadumel Era", new CollectItemObjective("Book8", 1));
		AddDrop("Book8", 10f, "boss_Goblin_Warrior_J2");

		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CRYOMANCER2_2_select1", "JOB_CRYOMANCER2_2", "I'll try to find them", "I'll wish for it next time"))
		{
			case 1:
				await dialog.Msg("JOB_CRYOMANCER2_2_prog1");
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

		if (character.Inventory.HasItem("Book8", 1))
		{
			character.Inventory.RemoveItem("Book8", 1);
			ZoneServer.Instance.World.FindNPC("MASTER_ICEMAGE")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
			await dialog.Msg("JOB_CRYOMANCER2_2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

