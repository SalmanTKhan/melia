//--- Melia Script -----------------------------------------------------------
// Prevent the dimension from collapsing
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sage Envoy..
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

[QuestScript(91101)]
public class Quest91101Script : QuestScript
{
	protected override void Load()
	{
		SetId(91101);
		SetName("Prevent the dimension from collapsing");
		SetDescription("Talk to the Sage Envoy.");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("D_CASTLE_19_1_PORTAL_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_PORTAL_NPC_01", "BeforeEnd", BeforeEnd);
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
}

