//--- Melia Script -----------------------------------------------------------
// The Missing Bishop (5)
//--- Description -----------------------------------------------------------
// Quest to Talk with Agent Cherasia.
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

[QuestScript(60089)]
public class Quest60089Script : QuestScript
{
	protected override void Load()
	{
		SetId(60089);
		SetName("The Missing Bishop (5)");
		SetDescription("Talk with Agent Cherasia");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORSHA_MQ1_04"));

		AddObjective("collect0", "Collect 4 Priest Irma's Journal Page(s)", new CollectItemObjective("SIAU15RE_MQ_01_ITEM", 4));
		AddDrop("SIAU15RE_MQ_01_ITEM", 6f, 58011, 400005, 58010, 58091);

		AddReward(new ExpReward(5000, 5000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("SIAU15RE_MQ_01_1_ITEM", 1));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_CHERASIA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_CHERASIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU15RE_MQ_01_01", "SIAU15RE_MQ_01", "I'll try to find them", "I think it'll be too late already"))
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

