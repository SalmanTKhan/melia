//--- Melia Script -----------------------------------------------------------
// Thirst for Drinks
//--- Description -----------------------------------------------------------
// Quest to Talk to the villager .
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

[QuestScript(80024)]
public class Quest80024Script : QuestScript
{
	protected override void Load()
	{
		SetId(80024);
		SetName("Thirst for Drinks");
		SetDescription("Talk to the villager ");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_06"));

		AddObjective("collect0", "Collect 10 Gigantic Fruit Juice(s)", new CollectItemObjective("ORCHARD_323_SQ_01_ITEM", 10));
		AddDrop("ORCHARD_323_SQ_01_ITEM", 10f, 57852, 57853, 57854);

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ORCHARD323_PEOPLE", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_PEOPLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_323_SQ_01_start", "ORCHARD_323_SQ_01", "I'll get it", "Why don't you ask for help around here?", "I don't have time for that"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ORCHARD_323_SQ_01_add");
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

