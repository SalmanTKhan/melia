//--- Melia Script -----------------------------------------------------------
// To a Safe Place
//--- Description -----------------------------------------------------------
// Quest to Make a conversation with Edmundas.
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

[QuestScript(91169)]
public class Quest91169Script : QuestScript
{
	protected override void Load()
	{
		SetId(91169);
		SetName("To a Safe Place");
		SetDescription("Make a conversation with Edmundas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY1_5_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_4"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_AD3", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY1_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY1_5_DLG1", "EP15_1_F_ABBEY1_5", "Alright", "That's not something I want to do."))
		{
			case 1:
				await dialog.Msg("EP15_1_F_ABBEY1_5_DLG2");
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP15_1_FABBEY1_ROZE3");
				dialog.HideNPC("EP15_1_FABBEY1_AD3");
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


		return HookResult.Break;
	}
}

