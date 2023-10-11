//--- Melia Script -----------------------------------------------------------
// Disarming the Second Defensive Device
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72197)]
public class Quest72197Script : QuestScript
{
	protected override void Load()
	{
		SetId(72197);
		SetName("Disarming the Second Defensive Device");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_90_MQ_70_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(379));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_90_MQ_60"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 19708));

		AddDialogHook("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_90_2ND_DEFENCE_DEVICE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_90_MQ_70_DLG1", "STARTOWER_90_MQ_70", "Alright", "I need to rest."))
		{
			case 1:
				// Func/SCR_STARTOWER_90_MQ_ADAUX_CONNECT_END;
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

		//SCR_D_STARTOWER_90_MQ_70_END
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The traps are no longer working after the Defensive Devices were shut down.{nl}Now go and talk to Elder Adaux.");
		// Func/SCR_STARTOWER_DEFENCE_DEVICE_UNLOCK_EFFECT;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

