//--- Melia Script -----------------------------------------------------------
// The Goddess' Flower (1)
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

[QuestScript(50193)]
public class Quest50193Script : QuestScript
{
	protected override void Load()
	{
		SetId(50193);
		SetName("The Goddess' Flower (1)");
		SetDescription("Talk with Priest Gherriti");

		AddPrerequisite(new LevelPrerequisite(307));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14122));

		AddDialogHook("BRACKEN431_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN431_SUBQ_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_1_SQ1_START1", "BRACKEN43_1_SQ1", "I am willing to help, what should I do?", "All I can say is \"Cheer up.\""))
		{
			case 1:
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("BRACKEN43_1_SQ1_AGREE1");
				await dialog.Msg("보따리에서 주운 씨앗을 보여준다");
				await dialog.Msg("BRACKEN43_1_SQ1_AGREE2");
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

		await dialog.Msg("BRACKEN43_1_SQ1SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

