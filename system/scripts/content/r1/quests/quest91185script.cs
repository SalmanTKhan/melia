//--- Melia Script -----------------------------------------------------------
// Two Seal Stones (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(91185)]
public class Quest91185Script : QuestScript
{
	protected override void Load()
	{
		SetId(91185);
		SetName("Two Seal Stones (2)");
		SetDescription("Talk to Edmundas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY_3_4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(487));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_3"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("AD3_FOLLOWNPC_CHAT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY_3_4_DLG1", "EP15_1_F_ABBEY_3_4", "Alright", "Let's heal the wound first."))
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
		character.Quests.Start("EP15_1_F_ABBEY_3_5");
	}
}

