//--- Melia Script -----------------------------------------------------------
// The Truth Behind the Epidemic (2)
//--- Description -----------------------------------------------------------
// Quest to Collect the Epidemic Detectors at Nobreer Intersection.
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

[QuestScript(30282)]
public class Quest30282Script : QuestScript
{
	protected override void Load()
	{
		SetId(30282);
		SetName("The Truth Behind the Epidemic (2)");
		SetDescription("Collect the Epidemic Detectors at Nobreer Intersection");

		AddPrerequisite(new LevelPrerequisite(322));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_8"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15134));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("WTREES_21_2_SQ_9_succ");
		dialog.HideNPC("WTREES_21_2_OBJ_2_1");
		dialog.HideNPC("WTREES_21_2_OBJ_2_2");
		dialog.HideNPC("WTREES_21_2_OBJ_2_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

