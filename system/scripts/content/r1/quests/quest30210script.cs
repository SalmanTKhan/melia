//--- Melia Script -----------------------------------------------------------
// Pass the Tree Vines(2)
//--- Description -----------------------------------------------------------
// Quest to Search the Chest of Materials for Neutralizer reagent.
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

[QuestScript(30210)]
public class Quest30210Script : QuestScript
{
	protected override void Load()
	{
		SetId(30210);
		SetName("Pass the Tree Vines(2)");
		SetDescription("Search the Chest of Materials for Neutralizer reagent");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_5"));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("ORCHARD_34_3_SQ_ITEM6", 1));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_OBJ_5", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_OBJ_6", "BeforeEnd", BeforeEnd);
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

		ZoneServer.Instance.World.FindNPC("ORCHARD_34_3_SQ_OBJ_6")?.PlayEffectLocal(character.Connection, "F_ground020", 1.0f, "BOT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

