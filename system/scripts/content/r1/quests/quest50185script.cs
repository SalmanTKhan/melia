//--- Melia Script -----------------------------------------------------------
// Retreat (2)
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

[QuestScript(50185)]
public class Quest50185Script : QuestScript
{
	protected override void Load()
	{
		SetId(50185);
		SetName("Retreat (2)");
		SetDescription("Talk to Soldier Andre");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_74_SQ2_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_74_SQ1"));

		AddObjective("kill0", "Kill 7 Brown Tini Magician(s) or Black Kepari(s)", new KillObjective(7, 57904, 57878));

		AddReward(new ExpReward(8865549, 8865549));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("TABLE74_SUBQ_SOLDIER1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_SOLDIER2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_74_SQ2_startnpc1", "TABLELAND_74_SQ2", "I'll save your troops.", "You should ask another army for help."))
		{
			case 1:
				await dialog.Msg("TABLELAND_74_SQ2_startnpc2");
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

		await dialog.Msg("TABLELAND_74_SQ2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

