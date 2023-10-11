//--- Melia Script -----------------------------------------------------------
// Bad Feelings Are Never Wrong
//--- Description -----------------------------------------------------------
// Quest to Use the scroll on the Divine Power Suppression Device.
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

[QuestScript(70586)]
public class Quest70586Script : QuestScript
{
	protected override void Load()
	{
		SetId(70586);
		SetName("Bad Feelings Are Never Wrong");
		SetDescription("Use the scroll on the Divine Power Suppression Device");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "PILGRIM41_5_SQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(271));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ06"));
		AddPrerequisite(new ItemPrerequisite("PILGRIM41_5_SQ06_ITEM", -100));

		AddObjective("kill0", "Kill 9 Red Ticen(s) or Red Ticen Magician(s) or Brown Nuka(s)", new KillObjective(9, 57957, 57961, 57986));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_08", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("PILGRIM415_SQ_07_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

