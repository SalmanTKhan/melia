//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Oscaras.
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

[QuestScript(50203)]
public class Quest50203Script : QuestScript
{
	protected override void Load()
	{
		SetId(50203);
		SetName("Danger the Lurks in the Forest (2)");
		SetDescription("Talk with Oscaras");

		AddPrerequisite(new LevelPrerequisite(310));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ1"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14260));

		AddDialogHook("BRACKEN432_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN432_SUBQ_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_2_SQ2_START1", "BRACKEN43_2_SQ2", "What should I get?", "Do it yourself."))
		{
			case 1:
				await dialog.Msg("BRACKEN43_2_SQ2_AGREE1");
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

		await dialog.Msg("BRACKEN43_2_SQ2_SUCC1");
		await dialog.Msg("BalloonText/BRACKEN432_SUBQ2_DLG1/4");
		await dialog.Msg("FadeOutIN/2000");
		dialog.UnHideNPC("BRACKEN432_SUBQ3_MON_A");
		dialog.UnHideNPC("BRACKEN432_SUBQ3_MON_B");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

