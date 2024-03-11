//--- Melia Script -----------------------------------------------------------
// Retreat (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Andre.
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

[QuestScript(50184)]
public class Quest50184Script : QuestScript
{
	protected override void Load()
	{
		SetId(50184);
		SetName("Retreat (1)");
		SetDescription("Talk to Soldier Andre");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_74_SQ1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(253));

		AddObjective("kill0", "Kill 5 Blue Harugal(s) or Brown Tini Magician(s)", new KillObjective(5, 57979, 57904));

		AddReward(new ExpReward(8865549, 8865549));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("TABLE74_SUBQ_SOLDIER1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_SOLDIER1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_74_SQ1_startnpc1", "TABLELAND_74_SQ1", "Ask what's going on", "Ignore"))
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

		await dialog.Msg("TABLELAND_74_SQ1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

