//--- Melia Script -----------------------------------------------------------
// To Overlong Bridge Valley
//--- Description -----------------------------------------------------------
// Quest to Talk to Gustas Jonas.
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

[QuestScript(40020)]
public class Quest40020Script : QuestScript
{
	protected override void Load()
	{
		SetId(40020);
		SetName("To Overlong Bridge Valley");
		SetDescription("Talk to Gustas Jonas");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_TO_26_ZACHA01"));

		AddDialogHook("ROKAS26_MQ1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS25_TO_26_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

