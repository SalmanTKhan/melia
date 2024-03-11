//--- Melia Script -----------------------------------------------------------
// The Final Mission (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wandering Spirit.
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

[QuestScript(20237)]
public class Quest20237Script : QuestScript
{
	protected override void Load()
	{
		SetId(20237);
		SetName("The Final Mission (1)");
		SetDescription("Talk to the Wandering Spirit");

		AddPrerequisite(new LevelPrerequisite(103));

		AddDialogHook("REMAINS39_GHOST", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_GHOST_BAG_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN39_SQ01_01", "REMAIN39_SQ01", "Start conversation", "Just pass by"))
		{
			case 1:
				await dialog.Msg("REMAIN39_SQ01_03");
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

		// Func/REMAINS39_GHOST_BAG_1;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAIN39_SQ02");
	}
}

