//--- Melia Script -----------------------------------------------------------
// Young Magician Owyn (2)
//--- Description -----------------------------------------------------------
// Quest to Owyn's Request.
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

[QuestScript(17003)]
public class Quest17003Script : QuestScript
{
	protected override void Load()
	{
		SetId(17003);
		SetName("Young Magician Owyn (2)");
		SetDescription("Owyn's Request");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_SQ_01"));

		AddObjective("kill0", "Kill 10 Drake(s)", new KillObjective(10, MonsterId.Fire_Dragon));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_SQ_02_ST", "FTOWER41_SQ_02", "I'll take care of Drake", "Well then, I shall get going. Goodbye."))
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

		await dialog.Msg("FTOWER41_SQ_02_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

