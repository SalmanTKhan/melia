//--- Melia Script -----------------------------------------------------------
// A Monk's Last Mission (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Abels.
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

[QuestScript(50132)]
public class Quest50132Script : QuestScript
{
	protected override void Load()
	{
		SetId(50132);
		SetName("A Monk's Last Mission (1)");
		SetDescription("Talk to Monk Abels");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("ABBEY642_MONK01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY642_MONK01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_2_SQ040_startnpc01", "ABBAY_64_2_SQ040", "I'll collect some right away", "I'm not so sure I can help you"))
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


		return HookResult.Break;
	}
}

