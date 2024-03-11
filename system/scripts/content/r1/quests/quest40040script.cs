//--- Melia Script -----------------------------------------------------------
// Rolandas Jonas of Akmens Ridge
//--- Description -----------------------------------------------------------
// Quest to .
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

[QuestScript(40040)]
public class Quest40040Script : QuestScript
{
	protected override void Load()
	{
		SetId(40040);
		SetName("Rolandas Jonas of Akmens Ridge");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_MQ1"));

		AddDialogHook("ROKAS27_REXITHER_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS26_MQ2_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

