//--- Melia Script -----------------------------------------------------------
// Unstable Compass
//--- Description -----------------------------------------------------------
// Quest to Survive the battle.
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

[QuestScript(91223)]
public class Quest91223Script : QuestScript
{
	protected override void Load()
	{
		SetId(91223);
		SetName("Unstable Compass");
		SetDescription("Survive the battle");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "SCR_EP16_1_PILGRIM_36_2_MQ13_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_PILGRIM_36_2_MQ12"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeEnd", BeforeEnd);
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

