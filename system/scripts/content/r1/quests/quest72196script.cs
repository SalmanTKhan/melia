//--- Melia Script -----------------------------------------------------------
// Across the Barrier
//--- Description -----------------------------------------------------------
// Quest to Investigate the Sculpture.
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

[QuestScript(72196)]
public class Quest72196Script : QuestScript
{
	protected override void Load()
	{
		SetId(72196);
		SetName("Across the Barrier");
		SetDescription("Investigate the Sculpture");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_90_MQ_60_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(379));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_90_MQ_50"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("D_STARTOWER_90_STATUE", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_90_MQ_60_DLG1", "STARTOWER_90_MQ_60", "Head for the Invisible Barrier.", "Take some time to prepare first."))
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

		//SCR_D_STARTOWER_90_MQ_60_END
		await dialog.Msg("STARTOWER_90_MQ_60_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

