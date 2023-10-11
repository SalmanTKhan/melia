//--- Melia Script -----------------------------------------------------------
// Forest of Fear
//--- Description -----------------------------------------------------------
// Quest to Talk to the Scared Owl Sculpture.
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

[QuestScript(4819)]
public class Quest4819Script : QuestScript
{
	protected override void Load()
	{
		SetId(4819);
		SetName("Forest of Fear");
		SetDescription("Talk to the Scared Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(112));

		AddDialogHook("KATYN13_1_KEYNPC", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_OWLBOSS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN13_1_Q1_11", "KATYN13_1_KEY", "I will deliver the Piece of Wing", "Decline"))
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

		await dialog.Msg("KATYN13_1_Q1_13");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN13_1_TO_OWLJUNIOR1");
	}
}

