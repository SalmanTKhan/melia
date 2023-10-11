//--- Melia Script -----------------------------------------------------------
// The Vulnerable Fugitive (1)
//--- Description -----------------------------------------------------------
// Quest to Search the Baltinel Memorial.
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

[QuestScript(60281)]
public class Quest60281Script : QuestScript
{
	protected override void Load()
	{
		SetId(60281);
		SetName("The Vulnerable Fugitive (1)");
		SetDescription("Search the Baltinel Memorial");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL105_SQ_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(371));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19000));

		AddDialogHook("DCAPITAL105_SQ_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL105_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("DCAPITAL105_SQ_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

