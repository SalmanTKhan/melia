//--- Melia Script -----------------------------------------------------------
// Putting Spices (2)
//--- Description -----------------------------------------------------------
// Quest to Contaminate the Stolen Food With Red Water.
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

[QuestScript(80026)]
public class Quest80026Script : QuestScript
{
	protected override void Load()
	{
		SetId(80026);
		SetName("Putting Spices (2)");
		SetDescription("Contaminate the Stolen Food With Red Water");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_SQ_02"));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ORCHARD323_PEOPLE", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_PEOPLE", "BeforeEnd", BeforeEnd);
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

	public override void OnStart(Character character, Quest quest)
	{
		// Func/ORCHARD_323_SQ_03_START;
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("ORCHARD323_FOOD");
		dialog.UnHideNPC("ORCHARD323_FOOD_F");
	}
}

