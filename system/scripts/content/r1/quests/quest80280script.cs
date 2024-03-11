//--- Melia Script -----------------------------------------------------------
// Reactivating the Water Facility (3)
//--- Description -----------------------------------------------------------
// Quest to Check the Water Point.
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

[QuestScript(80280)]
public class Quest80280Script : QuestScript
{
	protected override void Load()
	{
		SetId(80280);
		SetName("Reactivating the Water Facility (3)");
		SetDescription("Check the Water Point");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_3CMLAKE_86_SQ_03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_SQ_02"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_SQ_03_OBJ", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("F_3CMLAKE_86_SQ_03_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

