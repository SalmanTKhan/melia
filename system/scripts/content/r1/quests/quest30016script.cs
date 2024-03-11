//--- Melia Script -----------------------------------------------------------
// Object Left by the Master
//--- Description -----------------------------------------------------------
// Quest to Examine the Master's Legacy.
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

[QuestScript(30016)]
public class Quest30016Script : QuestScript
{
	protected override void Load()
	{
		SetId(30016);
		SetName("Object Left by the Master");
		SetDescription("Examine the Master's Legacy");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_04_SQ_09_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(191));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_04_SQ_08"));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 5921));

		AddDialogHook("CATACOMB_04_OBJ_07", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_2_NPC_02", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("CATACOMB_04_SQ_09_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

