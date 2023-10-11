//--- Melia Script -----------------------------------------------------------
// Fragment Finder
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Raymond.
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

[QuestScript(20199)]
public class Quest20199Script : QuestScript
{
	protected override void Load()
	{
		SetId(20199);
		SetName("Fragment Finder");
		SetDescription("Talk to Epigraphist Raymond");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAIN37_MQ03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(96));

		AddObjective("collect0", "Collect 1 Second Tombstone Fragment", new CollectItemObjective("REMAINS37_MSTONE_02", 1));
		AddDrop("REMAINS37_MSTONE_02", 10f, "boss_Achat_Q1");

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_RAYMOND", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_RAYMOND", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_MQ_3_succ01", "REMAIN37_MQ03", "I will find it", "About Ruklys memorial", "Find other things first"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("REMAIN37_MQ_3_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("REMAINS37_MSTONE_02", 1))
		{
			character.Inventory.RemoveItem("REMAINS37_MSTONE_02", 1);
			await dialog.Msg("REMAIN37_MQ03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

