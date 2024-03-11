//--- Melia Script -----------------------------------------------------------
// Removing Pollutants in Veidma Uphill
//--- Description -----------------------------------------------------------
// Quest to Check the source of corruption in Veidma Uphill.
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

[QuestScript(18160)]
public class Quest18160Script : QuestScript
{
	protected override void Load()
	{
		SetId(18160);
		SetName("Removing Pollutants in Veidma Uphill");
		SetDescription("Check the source of corruption in Veidma Uphill");

		AddPrerequisite(new LevelPrerequisite(46));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 690));

		AddDialogHook("HUEVILLAGE_58_1_SQ02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_1_SQ02_NPC", "BeforeEnd", BeforeEnd);
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

		dialog.HideNPC("HUEVILLAGE_58_1_SQ02_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

