//--- Melia Script -----------------------------------------------------------
// Growing Ominous Aura (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(91145)]
public class Quest91145Script : QuestScript
{
	protected override void Load()
	{
		SetId(91145);
		SetName("Growing Ominous Aura (2)");
		SetDescription("Talk to General Ramin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE2_MQ_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(475));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_1"));

		AddObjective("kill0", "Kill 8 Blickferret Lancer(s) or Grasme Bird(s)", new KillObjective(8, 59749, 59744));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_2_LAMIN1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE2_MQ_2_DLG1", "EP14_2_DCASTLE2_MQ_2", "What happened?", "Let's talk later."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

