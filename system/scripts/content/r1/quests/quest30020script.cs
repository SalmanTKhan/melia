//--- Melia Script -----------------------------------------------------------
// You have some senses
//--- Description -----------------------------------------------------------
// Quest to Destroy the Pot of Silence.
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

[QuestScript(30020)]
public class Quest30020Script : QuestScript
{
	protected override void Load()
	{
		SetId(30020);
		SetName("You have some senses");
		SetDescription("Destroy the Pot of Silence");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_38_1_SQ_04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(194));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_1_SQ_03"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6014));

		AddDialogHook("CATACOMB_38_1_OBJ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_1_NPC_02", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("CATACOMB_38_1_SQ_04_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_1_SQ_05");
	}
}

