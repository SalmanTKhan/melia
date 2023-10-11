//--- Melia Script -----------------------------------------------------------
// Preparing for Battle (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Talon.
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

[QuestScript(50149)]
public class Quest50149Script : QuestScript
{
	protected override void Load()
	{
		SetId(50149);
		SetName("Preparing for Battle (1)");
		SetDescription("Talk to Assistant Commander Talon");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_70_SQ4_AFTER_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ3"));

		AddDialogHook("TABLE70_CAPTIN1_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ4_startnp01", "TABLELAND_70_SQ4", "Let's fight the demons together.", "We should get out of here."))
		{
			case 1:
				await dialog.Msg("TABLELAND_70_SQ4_startnp02");
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

		await dialog.Msg("TABLELAND_70_SQ4_succ01");
		dialog.HideNPC("TABLE70_CAPTIN1_1");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("TABLE70_CAPTIN1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

