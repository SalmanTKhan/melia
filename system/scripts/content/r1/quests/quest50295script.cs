//--- Melia Script -----------------------------------------------------------
// Restoring Lucienne's Honor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Gatre.
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

[QuestScript(50295)]
public class Quest50295Script : QuestScript
{
	protected override void Load()
	{
		SetId(50295);
		SetName("Restoring Lucienne's Honor (1)");
		SetDescription("Talk with Gatre");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_12"), new CompletedPrerequisite("SIAULIAI_35_1_SQ_10"));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_4", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD343_HQ1_start1", "ORCHARD343_HQ1", "I'll deliver the report right away.", "Please deliver the report yourself."))
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

		await dialog.Msg("ORCHARD343_HQ1_succ1");
		await dialog.Msg("FadeOutIN/1000");
		await dialog.Msg("BalloonText/ORCHARD343_HQ1_infor1/3");
		await dialog.Msg("ORCHARD343_HQ1_succ2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD343_HQ2");
	}
}

