//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (3)
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

[QuestScript(50204)]
public class Quest50204Script : QuestScript
{
	protected override void Load()
	{
		SetId(50204);
		SetName("Danger the Lurks in the Forest (3)");
		SetDescription("Talk with Oscaras");

		AddPrerequisite(new LevelPrerequisite(310));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ2"));

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

		switch (await dialog.Select("BRACKEN43_2_SQ3_START1", "BRACKEN43_2_SQ3", "What should I do?", "Tell him to do it himself"))
		{
			case 1:
				// Func/BRACKEN432_SUBQ3_AGREE_FUNC;
				await dialog.Msg("BRACKEN43_2_SQ3_AGREE1");
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

		await dialog.Msg("BRACKEN43_2_SQ3_SUCC1");
		// Func/BRACKEN432_SUBQ3_AFTER_TRACK;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

