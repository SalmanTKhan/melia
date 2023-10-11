//--- Melia Script -----------------------------------------------------------
// Unexpected Discovery (4)
//--- Description -----------------------------------------------------------
// Quest to Look closely at the wing that is stuck on the ground.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(40310)]
public class Quest40310Script : QuestScript
{
	protected override void Load()
	{
		SetId(40310);
		SetName("Unexpected Discovery (4)");
		SetDescription("Look closely at the wing that is stuck on the ground");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_2_SQ_040_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(89));

		AddObjective("collect0", "Collect 1 Small Stone Statue's Wings", new CollectItemObjective("FARM47_2_SQ_040_ITEM_1", 1));
		AddDrop("FARM47_2_SQ_040_ITEM_1", 10f, "boss_Fallen_Statue_Q2");

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("FARM47_WING_D", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JOANA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

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

