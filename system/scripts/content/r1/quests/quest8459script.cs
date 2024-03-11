            //--- Melia Script -----------------------------------------------------------
// New Market District (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Stonemason Canolyn.
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

[QuestScript(8459)]
public class Quest8459Script : QuestScript
{
	protected override void Load()
	{
		SetId(8459);
		SetName("New Market District (1)");
		SetDescription("Talk to Stonemason Canolyn");

		AddPrerequisite(new LevelPrerequisite(107));

		AddObjective("kill0", "Kill 9 Cockatrice(s)", new KillObjective(9, MonsterId.Cockatries));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_CANOLIN_01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_CANOLIN_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_SQ_01_01", "REMAINS40_SQ_01", "I'll defeat the Cockatrices.", "I'm busy"))
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

		await dialog.Msg("REMAINS40_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

