//--- Melia Script -----------------------------------------------------------
// Collect the Faulty Goods
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Draznie.
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

[QuestScript(60153)]
public class Quest60153Script : QuestScript
{
	protected override void Load()
	{
		SetId(60153);
		SetName("Collect the Faulty Goods");
		SetDescription("Talk with Priest Draznie");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("PRISON622_DRAZUNIE", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON622_DRAZUNIE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_RP_1_1", "PRISON622_RP_1", "Alright, I'll help you", "We should let that go"))
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

