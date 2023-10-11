//--- Melia Script -----------------------------------------------------------
// What Happened to the Owl Sculptures?
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sleeping Owl Sculpture.
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

[QuestScript(90032)]
public class Quest90032Script : QuestScript
{
	protected override void Load()
	{
		SetId(90032);
		SetName("What Happened to the Owl Sculptures?");
		SetDescription("Talk to the Sleeping Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_1"));

		AddDialogHook("KATYN_45_1_OWL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_AJEL1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("KATYN_45_1_SQ_2_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

