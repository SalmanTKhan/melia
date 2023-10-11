//--- Melia Script -----------------------------------------------------------
// Blurry Trail (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Rose.
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

[QuestScript(91176)]
public class Quest91176Script : QuestScript
{
	protected override void Load()
	{
		SetId(91176);
		SetName("Blurry Trail (1)");
		SetDescription("Talk to Rose");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY2_3_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(485));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_2"));

		AddObjective("kill0", "Kill 8 Vubbe Warrior(s) or Vubbe Rider(s)", new KillObjective(8, 59780, 59777));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY2_3_DLG1", "EP15_1_F_ABBEY2_3", "I feel it too.", "You need to rest."))
		{
			case 1:
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

		await dialog.Msg("EP15_1_F_ABBEY2_3_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_4");
	}
}

