//--- Melia Script -----------------------------------------------------------
// From Suspicion to Affirmation
//--- Description -----------------------------------------------------------
// Quest to Check the inscription on the wall.
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

[QuestScript(90090)]
public class Quest90090Script : QuestScript
{
	protected override void Load()
	{
		SetId(90090);
		SetName("From Suspicion to Affirmation");
		SetDescription("Check the inscription on the wall");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_70"));

		AddDialogHook("CATACOMB_25_4_SQ_80", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_SQ_80", "BeforeEnd", BeforeEnd);
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
		character.Quests.Start("CATACOMB_25_4_SQ_90");
	}
}

