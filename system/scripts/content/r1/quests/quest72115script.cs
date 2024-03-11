//--- Melia Script -----------------------------------------------------------
// Where the Blue Light Leads
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(72115)]
public class Quest72115Script : QuestScript
{
	protected override void Load()
	{
		SetId(72115);
		SetName("Where the Blue Light Leads");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE262_SQ01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(336));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ08"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15792));

		AddDialogHook("3CMLAKE_BLACKMAN03", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE262_SQ01_DLG01", "F_3CMLAKE262_SQ01", "I'll go check it out.", "I've just finished a battle. I can't."))
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

		await dialog.Msg("3CMLAKE262_SQ01_DLG02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

