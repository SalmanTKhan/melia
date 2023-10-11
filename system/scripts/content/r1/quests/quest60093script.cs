//--- Melia Script -----------------------------------------------------------
// Imminent Danger (2)
//--- Description -----------------------------------------------------------
// Quest to Deliver to Chaser Ulysses.
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

[QuestScript(60093)]
public class Quest60093Script : QuestScript
{
	protected override void Load()
	{
		SetId(60093);
		SetName("Imminent Danger (2)");
		SetDescription("Deliver to Chaser Ulysses");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU15RE_MQ_05"));

		AddReward(new ExpReward(2500, 2500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 1040));
		AddReward(new ItemReward("Drug_SP1_Q", 30));

		AddDialogHook("SIAULIAI15RE_YEULIS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_TALBASI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU15RE_MQ_06_01", "SIAU15RE_MQ_06", "I'll go right away", "I still have other things to do"))
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

