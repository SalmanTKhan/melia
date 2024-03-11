//--- Melia Script -----------------------------------------------------------
// Village Curse (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Village Priest Chaleims.
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

[QuestScript(50171)]
public class Quest50171Script : QuestScript
{
	protected override void Load()
	{
		SetId(50171);
		SetName("Village Curse (6)");
		SetDescription("Talk to Village Priest Chaleims");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_72_SQ7_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(246));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ6"));

		AddObjective("kill0", "Kill 6 Red Hohen Orben(s) or Brown Lapasape(s)", new KillObjective(6, 57975, 57942));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ7_startnpc1", "TABLELAND_72_SQ7", "I'll go find Arntas.", "Let's wait a little more."))
		{
			case 1:
				await dialog.Msg("TABLELAND_72_SQ7_prog1");
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

		await dialog.Msg("TABLELAND_72_SQ7_succ1");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("TABLE72_PEAPLE1_1");
		dialog.UnHideNPC("TABLE72_PEAPLE1_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

