//--- Melia Script -----------------------------------------------------------
// Commander Vacenin (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Commander Felix.
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

[QuestScript(4883)]
public class Quest4883Script : QuestScript
{
	protected override void Load()
	{
		SetId(4883);
		SetName("Commander Vacenin (2)");
		SetDescription("Talk to Commander Felix");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("KATYN_KEY_01"));
		AddPrerequisite(new ItemPrerequisite("katyn_7_Messenger", -100));

		AddDialogHook("KATYN7_KEYNPC_4", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN7_KEYNPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN7_MAIN_05_01", "SUCH_POINT_05", "Return to Camp", "I'll rest for a while"))
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

		await dialog.Msg("KATYN7_MAIN_05_02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

