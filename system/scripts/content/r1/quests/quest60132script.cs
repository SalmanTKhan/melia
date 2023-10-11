//--- Melia Script -----------------------------------------------------------
// What If Again (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Auranas.
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

[QuestScript(60132)]
public class Quest60132Script : QuestScript
{
	protected override void Load()
	{
		SetId(60132);
		SetName("What If Again (1)");
		SetDescription("Talk with Priest Auranas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("PRISON621_ARUNARAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_ARUNARAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_SQ_01_01", "PRISON622_SQ_01", "Yeah, I'll collect them", "I don't think that'll be needed"))
		{
			case 1:
				dialog.UnHideNPC("PRISON622_SQ_01_NPC");
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

