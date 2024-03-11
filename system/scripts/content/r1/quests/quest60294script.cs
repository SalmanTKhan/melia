//--- Melia Script -----------------------------------------------------------
// The Downward Spiral (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60294)]
public class Quest60294Script : QuestScript
{
	protected override void Load()
	{
		SetId(60294);
		SetName("The Downward Spiral (5)");
		SetDescription("Talk to Kupole Grisia");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_4"));

		AddDialogHook("DCAPITAL106_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL106_ZUSAIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL106_SQ_5_1", "DCAPITAL106_SQ_5", "I will pass this along.", "I need to prepare"))
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

		await dialog.Msg("DCAPITAL106_SQ_5_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

