//--- Melia Script -----------------------------------------------------------
// Devilglove Awakened
//--- Description -----------------------------------------------------------
// Quest to Talk to Rose.
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

[QuestScript(91180)]
public class Quest91180Script : QuestScript
{
	protected override void Load()
	{
		SetId(91180);
		SetName("Devilglove Awakened");
		SetDescription("Talk to Rose");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY2_7_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(485));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_6"));

		AddObjective("kill0", "Kill 1 Black Devilglove", new KillObjective(1, MonsterId.Boss_Blackdevilglove));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_ROZE2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY2_7_DLG1", "EP15_1_F_ABBEY2_7", "I'll destroy it.", "I have a bad feeling."))
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
		character.Quests.Start("EP15_1_F_ABBEY2_8");
	}
}

