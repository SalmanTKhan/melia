//--- Melia Script -----------------------------------------------------------
// Removing the Odor
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Pierneef.
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

[QuestScript(60095)]
public class Quest60095Script : QuestScript
{
	protected override void Load()
	{
		SetId(60095);
		SetName("Removing the Odor");
		SetDescription("Talk with Chaser Pierneef");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_FERNIFF", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_FERNIFF", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU15RE_SQ_02_01", "SIAU15RE_SQ_02", "I'll take care of it", "That's not for me; I have a weak stomach"))
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

