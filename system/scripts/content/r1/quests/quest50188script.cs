//--- Melia Script -----------------------------------------------------------
// Retreat (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Scout Boas.
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

[QuestScript(50188)]
public class Quest50188Script : QuestScript
{
	protected override void Load()
	{
		SetId(50188);
		SetName("Retreat (5)");
		SetDescription("Talk to Scout Boas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_74_SQ5_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_74_SQ4"));

		AddObjective("kill0", "Kill 7 Brown Tini Magician(s) or Blue Harugal(s)", new KillObjective(7, 57904, 57979));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("TABLE74_SUBQ_SOLDIER3_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_SOLDIER3_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_74_SQ5_startnpc1", "TABLELAND_74_SQ5", "I'll destroy them", "I need some time to prepare"))
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

		await dialog.Msg("TABLELAND_74_SQ5_succ1");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("TABLE74_SUBQ_SOLDIER3_2");
		dialog.UnHideNPC("TABLE74_SUBQ_SOLDIER3_3");
		// Func/TABLE74_SUBQ5_COMPLETE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

