//--- Melia Script -----------------------------------------------------------
// Weakened Girl, Rose
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(91167)]
public class Quest91167Script : QuestScript
{
	protected override void Load()
	{
		SetId(91167);
		SetName("Weakened Girl, Rose");
		SetDescription("Talk to Edmundas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY1_3_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_2"));

		AddObjective("kill0", "Kill 10 Vubbe Chaser(s)", new KillObjective(10, MonsterId.Ep15_1_Goblin_Chaser));

		AddReward(new ExpReward(5400000000, 5400000000));
		AddReward(new ItemReward("Vis", 125217));

		AddDialogHook("EP15_1_FABBEY1_AD1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY1_3_DLG1", "EP15_1_F_ABBEY1_3", "It's been a while.", "I don't remember."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

