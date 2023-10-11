//--- Melia Script -----------------------------------------------------------
// Fallen Days
//--- Description -----------------------------------------------------------
// Quest to Talk to Tess.
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

[QuestScript(60162)]
public class Quest60162Script : QuestScript
{
	protected override void Load()
	{
		SetId(60162);
		SetName("Fallen Days");
		SetDescription("Talk to Tess");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_MQ060"));

		AddObjective("collect0", "Collect 7 Lapasape Wand Fragment(s)", new CollectItemObjective("BRACKEN632_RP_1_ITEM", 7));
		AddDrop("BRACKEN632_RP_1_ITEM", 9f, "lapasape_mage");

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("BRACKEN632_TOWN_PEAPLE_1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_TOWN_PEAPLE_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN632_RP_1_1", "BRACKEN632_RP_1", "I'll make sure it's safe.", "I think you should hide better."))
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

