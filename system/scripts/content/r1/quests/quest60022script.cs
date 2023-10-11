//--- Melia Script -----------------------------------------------------------
// Hauberk in the Maze (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Sigita.
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

[QuestScript(60022)]
public class Quest60022Script : QuestScript
{
	protected override void Load()
	{
		SetId(60022);
		SetName("Hauberk in the Maze (5)");
		SetDescription("Talk to Kupole Sigita");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON513_MQ_05_TRACK", "m_booss_a");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("VPRISON513_MQ_04"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 38400));

		AddDialogHook("VPRISON513_MQ_SIGITA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON513_MQ_SIGITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON513_MQ_05_01", "VPRISON513_MQ_05", "I am ready", "I will prepare a lot"))
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

		await dialog.Msg("VPRISON513_MQ_05_03");
		dialog.UnHideNPC("VPRISON515_MQ_06_NPC");
		dialog.HideNPC("VPRISON514_MQ_VAKARINE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

