//--- Melia Script -----------------------------------------------------------
// Remove Mirtinas (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91156)]
public class Quest91156Script : QuestScript
{
	protected override void Load()
	{
		SetId(91156);
		SetName("Remove Mirtinas (1)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE3_MQ_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(478));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_1"));

		AddObjective("kill0", "Kill 6 Blickferret Scout(s) or Eerie Blickferret(s)", new KillObjective(6, 59750, 59751));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_DCASTLE3_PAJAUTA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE3_MQ_2_DLG1", "EP14_2_DCASTLE3_MQ_2", "I'll come after removing the Mirtinas.", "I need some time to prepare."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE3_MQ_3");
	}
}

