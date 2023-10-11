//--- Melia Script -----------------------------------------------------------
// New Researcher's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the New Researcher in the Royal Mausoleum.
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

[QuestScript(4429)]
public class Quest4429Script : QuestScript
{
	protected override void Load()
	{
		SetId(4429);
		SetName("New Researcher's Favor (2)");
		SetDescription("Talk to the New Researcher in the Royal Mausoleum");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_1"));

		AddObjective("collect0", "Collect 5 Royal Mausoleum Research Report(s)", new CollectItemObjective("ROKAS24_Bark_1", 5));
		AddDrop("ROKAS24_Bark_1", 8f, "Geppetto");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_NEWCOMER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_NEWCOMER", "BeforeEnd", BeforeEnd);
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS24_QB_3");
	}
}

