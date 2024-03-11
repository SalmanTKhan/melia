//--- Melia Script -----------------------------------------------------------
// Saving the Guide Owl
//--- Description -----------------------------------------------------------
// Quest to Find the Guide Owl Sculpture at Letas Stream.
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

[QuestScript(30060)]
public class Quest30060Script : QuestScript
{
	protected override void Load()
	{
		SetId(30060);
		SetName("Saving the Guide Owl");
		SetDescription("Find the Guide Owl Sculpture at Letas Stream");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_11"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

