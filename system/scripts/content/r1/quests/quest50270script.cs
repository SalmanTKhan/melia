//--- Melia Script -----------------------------------------------------------
// Monsters after Monsters
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Pierneef.
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

[QuestScript(50270)]
public class Quest50270Script : QuestScript
{
	protected override void Load()
	{
		SetId(50270);
		SetName("Monsters after Monsters");
		SetDescription("Talk with Chaser Pierneef");

		AddPrerequisite(new LevelPrerequisite(8));

		AddReward(new ItemReward("misc_silverbar", 1));

		AddDialogHook("SIAULIAI15RE_FERNIFF", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI17_HQ1_start1", "SIAULIAI15_HQ1", "I'll bring the report to the Lord.", "You ought to report to her yourself."))
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

		await dialog.Msg("SIAULIAI17_HQ1_succ1");
		// Func/SIAULIAI15_HIDDENTQ1_FUNC;
		await dialog.Msg("BalloonText/SIAULIAI15_HQ1_MSG1/3");
		await dialog.Msg("FadeOutIN/1000");
		await dialog.Msg("SIAULIAI17_HQ1_succ2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

