//--- Melia Script -----------------------------------------------------------
// Setbacks (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jamelhan.
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

[QuestScript(50158)]
public class Quest50158Script : QuestScript
{
	protected override void Load()
	{
		SetId(50158);
		SetName("Setbacks (1)");
		SetDescription("Talk to Jamelhan");

		AddPrerequisite(new LevelPrerequisite(242));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_71_SQ1"));

		AddObjective("kill0", "Kill 10 Blue Hohen Ritter(s) or Blue Hohen Barkle(s) or Blue Tini(s) or Blue Cronewt Poisoned Needler(s)", new KillObjective(10, 57969, 57971, 57902, 57954));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 8954));

		AddDialogHook("TABLE71_PEAPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ2_startnpc01", "TABLELAND_71_SQ2", "I'll help you, you can talk to me.", "I don't see the need for that."))
		{
			case 1:
				await dialog.Msg("TABLELAND_71_SQ2_startnpc02");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("TABLELAND_71_SQ2_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

