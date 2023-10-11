//--- Melia Script -----------------------------------------------------------
// Unexpected Situation(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Spirit in the Interrogation Room.
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

[QuestScript(30184)]
public class Quest30184Script : QuestScript
{
	protected override void Load()
	{
		SetId(30184);
		SetName("Unexpected Situation(1)");
		SetDescription("Talk to Zanas' Spirit in the Interrogation Room");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "PRISON_82_MQ_1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_10"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 31));

		AddDialogHook("PRISON_82_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_82_MQ_1_select", "PRISON_82_MQ_1", "Ask if he presumes somthing", "Say that he is worrying too much"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

