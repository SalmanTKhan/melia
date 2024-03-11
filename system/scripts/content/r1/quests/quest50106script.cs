//--- Melia Script -----------------------------------------------------------
// Demon Herbalist (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Ash.
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

[QuestScript(50106)]
public class Quest50106Script : QuestScript
{
	protected override void Load()
	{
		SetId(50106);
		SetName("Demon Herbalist (2)");
		SetDescription("Talk to Herbalist Ash");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_SQ020"));

		AddObjective("collect0", "Collect 15 Loktanun Fluid(s)", new CollectItemObjective("BRACKEN632_SQ2_ITEM01", 15));
		AddDrop("BRACKEN632_SQ2_ITEM01", 10f, "Loktanun");

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_2_SQ030_startnpc01", "BRACKEN_63_2_SQ030", "I'll get it quickly", "First we need to find somewhere safe"))
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

