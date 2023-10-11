//--- Melia Script -----------------------------------------------------------
// What If Again (2)
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

[QuestScript(60133)]
public class Quest60133Script : QuestScript
{
	protected override void Load()
	{
		SetId(60133);
		SetName("What If Again (2)");
		SetDescription("Talk with Priest Auranas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON622_SQ_01"));

		AddObjective("kill0", "Kill 9 Bat(s) or Blue Vubbe Archer(s) or Blue Vubbe Thief(s) or Wendigo Escapee(s)", new KillObjective(9, 58096, 58092, 11124, 58111));

		AddReward(new ExpReward(8058, 8058));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("PRISON621_ARUNARAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_ARUNARAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_SQ_02_01", "PRISON622_SQ_02", "I will try", "I need some time to prepare"))
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

