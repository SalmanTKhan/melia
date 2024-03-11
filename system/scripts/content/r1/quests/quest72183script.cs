//--- Melia Script -----------------------------------------------------------
// Take back the First Control Room
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72183)]
public class Quest72183Script : QuestScript
{
	protected override void Load()
	{
		SetId(72183);
		SetName("Take back the First Control Room");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_89_MQ_30_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_20"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19500));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_1ST_DEFENCE_DEVICE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_89_MQ_30_DLG1", "STARTOWER_89_MQ_30", "Alright", "I'm not ready."))
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

		//SCR_D_STARTOWER_89_MQ_30_TRACK_END
		// Func/SCR_STARTOWER_DEFENCE_DEVICE_UNLOCK_EFFECT/0;
		// Func/SCR_D_STARTOWER_89_MQ_30_AFTER_TRACK_PLAY;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

