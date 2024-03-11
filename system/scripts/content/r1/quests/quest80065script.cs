//--- Melia Script -----------------------------------------------------------
// The Alchemist of Nahash Forest (1)
//--- Description -----------------------------------------------------------
// Quest to Search the abandoned tent.
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

[QuestScript(80065)]
public class Quest80065Script : QuestScript
{
	protected override void Load()
	{
		SetId(80065);
		SetName("The Alchemist of Nahash Forest (1)");
		SetDescription("Search the abandoned tent");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_16"));

		AddReward(new ItemReward("SIAULIAI_35_1_SQ_POTION", 1));

		AddDialogHook("SIAULIAI_35_1_SQ_1_START", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_ALCHEMY_BAG", "BeforeEnd", BeforeEnd);
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
		character.Quests.Start("SIAULIAI_35_1_SQ_2");
	}
}

