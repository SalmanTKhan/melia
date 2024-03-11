//--- Melia Script -----------------------------------------------------------
// The Hidden Sanctum's Revelation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Algis.
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

[QuestScript(8537)]
public class Quest8537Script : QuestScript
{
	protected override void Load()
	{
		SetId(8537);
		SetName("The Hidden Sanctum's Revelation (1)");
		SetDescription("Talk to Follower Algis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHAPLE577_MQ_10_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(48));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_09"));

		AddReward(new ExpReward(84420, 84420));
		AddReward(new ItemReward("stonetablet02", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));

		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE577_MQ_10_01", "CHAPLE577_MQ_10", "I'll go there", "There is still more to do"))
		{
			case 1:
				await dialog.Msg("CHAPLE577_MQ_10_AG");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

