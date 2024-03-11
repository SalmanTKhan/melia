//--- Melia Script -----------------------------------------------------------
// Familiar Faces
//--- Description -----------------------------------------------------------
// Quest to Demon's Surprise Attack.
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

[QuestScript(92036)]
public class Quest92036Script : QuestScript
{
	protected override void Load()
	{
		SetId(92036);
		SetName("Familiar Faces");
		SetDescription("Demon's Surprise Attack");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_1_SQ_03_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_SQ_02"));

		AddDialogHook("EP13_F_SIAULIAI_1_SQ_02_TRG_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("EP13_F_SIAULIAI_1_SQ_03_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

