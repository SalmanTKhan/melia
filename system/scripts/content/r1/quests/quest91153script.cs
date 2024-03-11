//--- Melia Script -----------------------------------------------------------
// Spooky Black Energy
//--- Description -----------------------------------------------------------
// Quest to Talk to the General Ramin.
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

[QuestScript(91153)]
public class Quest91153Script : QuestScript
{
	protected override void Load()
	{
		SetId(91153);
		SetName("Spooky Black Energy");
		SetDescription("Talk to the General Ramin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE2_MQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(475));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_9"));

		AddObjective("kill0", "Kill 1 Blickferret Prey", new KillObjective(1, MonsterId.Boss_Bleakferret_Prey));

		AddReward(new ExpReward(2400000000, 2400000000));
		AddReward(new ItemReward("Vis", 60490));

		AddDialogHook("EP14_2_2_LAMIN2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE2_MQ_10_DLG4", "EP14_2_DCASTLE2_MQ_10", "Let's go.", "I'll prepare more since it's dangerous."))
		{
			case 1:
				dialog.HideNPC("EP14_2_2_LAMIN2");
				dialog.HideNPC("EP14_2_2_PAJAUTA2");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE2_MQ_11");
	}
}

