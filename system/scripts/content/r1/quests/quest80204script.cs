//--- Melia Script -----------------------------------------------------------
// Good Use For a Wand (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Ruodell.
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

[QuestScript(80204)]
public class Quest80204Script : QuestScript
{
	protected override void Load()
	{
		SetId(80204);
		SetName("Good Use For a Wand (4)");
		SetDescription("Talk to Priest Ruodell");

		AddPrerequisite(new LevelPrerequisite(142));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_SQ09"));

		AddObjective("kill0", "Kill 8 Blue Stoulet(s)", new KillObjective(8, MonsterId.Stoulet_Blue));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3692));

		AddDialogHook("CHATHEDRAL54_SQ04_PART2", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_SQ04_PART2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_SQ06_select01", "CHATHEDRAL54_SQ06", "I will defeat it", "I'm afraid"))
		{
			case 1:
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

		await dialog.Msg("CHATHEDRAL54_SQ06_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

