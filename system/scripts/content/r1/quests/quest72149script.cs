//--- Melia Script -----------------------------------------------------------
// Fedimian's Investigator (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elementalist Submaster.
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

[QuestScript(72149)]
public class Quest72149Script : QuestScript
{
	protected override void Load()
	{
		SetId(72149);
		SetName("Fedimian's Investigator (2)");
		SetDescription("Talk to the Elementalist Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MASTER_RANGER2_2_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(85));
		AddPrerequisite(new CompletedPrerequisite("MASTER_RANGER2_1"));

		AddObjective("collect0", "Collect 1 Cloth Piece with a Peculiar Scent", new CollectItemObjective("JOB_RANGER3_2_ITEM1", 1));
		AddDrop("JOB_RANGER3_2_ITEM1", 10f, "boss_Minotaurs_J1");

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_RANGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RANGER3_2_select1", "MASTER_RANGER2_2", "Where?", "I will get it again later"))
		{
			case 1:
				await dialog.Msg("JOB_RANGER3_2_prog1");
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

		if (character.Inventory.HasItem("JOB_RANGER3_2_ITEM1", 1))
		{
			character.Inventory.RemoveItem("JOB_RANGER3_2_ITEM1", 1);
			await dialog.Msg("MASTER_RANGER1_2_DLG2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

