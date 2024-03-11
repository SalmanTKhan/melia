//--- Melia Script -----------------------------------------------------------
// The Revelation of Kalejimas
//--- Description -----------------------------------------------------------
// Quest to Obtain the Revelation from the Confessional Secret Device.
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

[QuestScript(30194)]
public class Quest30194Script : QuestScript
{
	protected override void Load()
	{
		SetId(30194);
		SetName("The Revelation of Kalejimas");
		SetDescription("Obtain the Revelation from the Confessional Secret Device");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "PRISON_82_MQ_11_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_10"));
		AddPrerequisite(new ItemPrerequisite("PRISON_79_MQ_8_ITEM", -100), new ItemPrerequisite("PRISON_80_MQ_9_ITEM", -100), new ItemPrerequisite("PRISON_81_MQ_7_ITEM", -100), new ItemPrerequisite("PRISON_82_MQ_10_ITEM", -100), new ItemPrerequisite("PRISON_79_MQ_3_ITEM", -100));

		AddReward(new ExpReward(11281890, 11281890));
		AddReward(new ItemReward("stonetablet08", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 118));

		AddDialogHook("PRISON_82_OBJ_8", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

