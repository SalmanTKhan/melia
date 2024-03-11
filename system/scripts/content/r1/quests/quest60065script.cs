//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60065)]
public class Quest60065Script : QuestScript
{
	protected override void Load()
	{
		SetId(60065);
		SetName("The Journey to Find Myself (5)");
		SetDescription("Talk to Demon Lord Hauberk");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM312_SQ_05_AFTER", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_05"));

		AddDialogHook("PILGRIM312_HAUBERK_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_03", "BeforeEnd", BeforeEnd);
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

