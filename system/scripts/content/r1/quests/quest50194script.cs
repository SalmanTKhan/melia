//--- Melia Script -----------------------------------------------------------
// The Goddess' Flower (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gherriti.
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

[QuestScript(50194)]
public class Quest50194Script : QuestScript
{
	protected override void Load()
	{
		SetId(50194);
		SetName("The Goddess' Flower (2)");
		SetDescription("Talk with Priest Gherriti");

		AddPrerequisite(new LevelPrerequisite(307));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_1_SQ1"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14122));

		AddDialogHook("BRACKEN431_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_1_SQ2_START1", "BRACKEN43_1_SQ2", "I'll help you", "About why looking so tired", "Ask him to look for another person"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_1_SQ2_AGREE1");
				// Func/BRACKEN431_NPC_AI_CREATE;
				dialog.HideNPC("BRACKEN431_SUBQ_NPC1");
				await dialog.Msg("FadeOutIN/1000");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("BRACKEN43_1_SQ1_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("BRACKEN43_1_SQ2_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

