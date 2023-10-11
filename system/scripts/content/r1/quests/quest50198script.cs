//--- Melia Script -----------------------------------------------------------
// The Goddess' Flower (6)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gherriti.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(50198)]
public class Quest50198Script : QuestScript
{
	protected override void Load()
	{
		SetId(50198);
		SetName("The Goddess' Flower (6)");
		SetDescription("Talk with Priest Gherriti");

		AddPrerequisite(new LevelPrerequisite(307));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_1_SQ5"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14122));

		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_1_SQ6_START1", "BRACKEN43_1_SQ6", "I'll try to do it", "Sorry, something else came up"))
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

		await dialog.Msg("BRACKEN43_1_SQ6_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

