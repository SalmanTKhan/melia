//--- Melia Script -----------------------------------------------------------
// Collecting Information
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gelija.
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

[QuestScript(60142)]
public class Quest60142Script : QuestScript
{
	protected override void Load()
	{
		SetId(60142);
		SetName("Collecting Information");
		SetDescription("Talk with Priest Gelija");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 13 Marnox's Insignia(s)", new CollectItemObjective("PRISON623_SQ_01_ITEM", 13));
		AddDrop("PRISON623_SQ_01_ITEM", 7.5f, 58095, 58097, 58098, 400207);

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 350));

		AddDialogHook("PRISON623_GELIYA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON623_GELIYA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON623_SQ_01_01", "PRISON623_SQ_01", "Yeah, I'll collect them", "Decline"))
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

