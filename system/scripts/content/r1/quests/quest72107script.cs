//--- Melia Script -----------------------------------------------------------
// Demon Lord Solcomm
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

[QuestScript(72107)]
public class Quest72107Script : QuestScript
{
	protected override void Load()
	{
		SetId(72107);
		SetName("Demon Lord Solcomm");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE261_SQ08_TRACK", "m_boss_scenario3");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ07"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE_BLACKMAN03", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ08_DLG01", "F_3CMLAKE261_SQ08", "Alright", "It won't be much of a problem."))
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

		await dialog.Msg("3CMLAKE261_SQ08_DLG02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

