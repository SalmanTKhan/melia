//--- Melia Script -----------------------------------------------------------
// Secret of the Fletchers [Quarrel Shooter Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(1120)]
public class Quest1120Script : QuestScript
{
	protected override void Load()
	{
		SetId(1120);
		SetName("Secret of the Fletchers [Quarrel Shooter Advancement] (2)");
		SetDescription("Talk to the Sapper Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_QUARREL3_2_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(85));
		AddPrerequisite(new CompletedPrerequisite("JOB_QUARREL3_1"));

		AddObjective("collect0", "Collect 1 Strange Map", new CollectItemObjective("JOB_QUARREL3_2_ITEM1", 1));
		AddDrop("JOB_QUARREL3_2_ITEM1", 10f, "boss_Minotaurs_J1");

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_QUARREL3_2_select1", "JOB_QUARREL3_2", "Tell me where you saw the map", "I do not think my strength will be enough."))
		{
			case 1:
				await dialog.Msg("JOB_QUARREL3_2_prog1");
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

		if (character.Inventory.HasItem("JOB_QUARREL3_2_ITEM1", 1))
		{
			character.Inventory.RemoveItem("JOB_QUARREL3_2_ITEM1", 1);
			await dialog.Msg("JOB_QUARREL3_2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

