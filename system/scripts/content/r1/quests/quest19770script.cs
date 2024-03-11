//--- Melia Script -----------------------------------------------------------
// Genuine Goddess Statue (3)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Goddess Statue.
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

[QuestScript(19770)]
public class Quest19770Script : QuestScript
{
	protected override void Load()
	{
		SetId(19770);
		SetName("Genuine Goddess Statue (3)");
		SetDescription("Inspect the Goddess Statue");

		AddPrerequisite(new LevelPrerequisite(129));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM51_SQ_4_0"));

		AddObjective("collect0", "Collect 5 Grey Gypsum Fragment(s)", new CollectItemObjective("PILGRIM51_ITEM_03", 5));
		AddDrop("PILGRIM51_ITEM_03", 10f, 41315, 41451, 57613);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_FGOD02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_FGOD02", "BeforeEnd", BeforeEnd);
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

