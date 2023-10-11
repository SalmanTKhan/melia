//--- Melia Script -----------------------------------------------------------
// Fragment of a Soul
//--- Description -----------------------------------------------------------
// Quest to Cool the Altar.
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

[QuestScript(19701)]
public class Quest19701Script : QuestScript
{
	protected override void Load()
	{
		SetId(19701);
		SetName("Fragment of a Soul");
		SetDescription("Cool the Altar");

		AddPrerequisite(new LevelPrerequisite(127));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM50_SQ_040"));

		AddObjective("collect0", "Collect 10 Cold Monster Fluid(s)", new CollectItemObjective("PILGRIM50_SQ_091_ITEM", 10));
		AddDrop("PILGRIM50_SQ_091_ITEM", 10f, 41450, 57403, 57641, 57604);

		AddReward(new ExpReward(60312, 60312));
		AddReward(new ItemReward("expCard7", 1));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ALTAR03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_ALTAR03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


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

