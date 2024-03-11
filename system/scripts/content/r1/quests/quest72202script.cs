//--- Melia Script -----------------------------------------------------------
// Building Initiation (4)
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

[QuestScript(72202)]
public class Quest72202Script : QuestScript
{
	protected override void Load()
	{
		SetId(72202);
		SetName("Building Initiation (4)");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_91_MQ_40_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(382));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_91_MQ_30"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20246));

		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_91_4TH_SUB_DEVICE_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		//SCR_STARTOWER_91_MQ_40_END
		// Func/SCR_STARTOWER_90_SUB_DEVICE_UNLOCK_EFFECT;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've disarmed all Protective Devices!{nl}Report to Byle.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

