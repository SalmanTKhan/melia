//--- Melia Script -----------------------------------------------------------
// Purification of the Stream, Recovery of the Tree (2)
//--- Description -----------------------------------------------------------
// Quest to Purify the Pond of Silence with the sap of the Tree of the Brothers.
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

[QuestScript(19941)]
public class Quest19941Script : QuestScript
{
	protected override void Load()
	{
		SetId(19941);
		SetName("Purification of the Stream, Recovery of the Tree (2)");
		SetDescription("Purify the Pond of Silence with the sap of the Tree of the Brothers");

		AddPrerequisite(new LevelPrerequisite(133));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_080"));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_SPRING", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/SCR_PILGRIM52_SQ_081_TRACK_PLAY;
		dialog.HideNPC("PILGRIM52_TRUTHTREE");
		dialog.UnHideNPC("PILGRIM52_TRUTHTREE_REAL");
		dialog.HideNPC("PILGRIM52_WATERPOT01");
		dialog.HideNPC("PILGRIM52_WATERPOT02");
		dialog.HideNPC("PILGRIM52_WATERPOT03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

