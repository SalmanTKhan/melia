//--- Melia Script -----------------------------------------------------------
// Lead to a Dead-end (2)
//--- Description -----------------------------------------------------------
// Quest to Chase Delmore Rephaim to the Odaginkas Vacant Lot.
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

[QuestScript(70446)]
public class Quest70446Script : QuestScript
{
	protected override void Load()
	{
		SetId(70446);
		SetName("Lead to a Dead-end (2)");
		SetDescription("Chase Delmore Rephaim to the Odaginkas Vacant Lot");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "SCR_CASTLE653_MQ_07_TRACKSTART", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ06"));

		AddReward(new ExpReward(368565, 368565));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_07_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_07_2", "BeforeEnd", BeforeEnd);
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

