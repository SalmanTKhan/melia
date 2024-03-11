//--- Melia Script -----------------------------------------------------------
// Mysterious Attack
//--- Description -----------------------------------------------------------
// Quest to Find the Mystery Man.
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

[QuestScript(90124)]
public class Quest90124Script : QuestScript
{
	protected override void Load()
	{
		SetId(90124);
		SetName("Mysterious Attack");
		SetDescription("Find the Mystery Man");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "MAPLE_25_2_SQ_60_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_2_SQ_50"));

		AddObjective("kill0", "Kill 7 Rhodeliot(s)", new KillObjective(7, MonsterId.Roderiot));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("MAPLE_25_2_SQ_60", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_EIVYDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UnHideNPC/MAPLE_25_2_EIVYDAS/0", "MAPLE_25_2_SQ_60"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("MAPLE_25_2_SQ_60_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

