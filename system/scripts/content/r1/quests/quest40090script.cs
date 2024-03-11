//--- Melia Script -----------------------------------------------------------
// Working on the Landfill (3)
//--- Description -----------------------------------------------------------
// Quest to Check out the suspicious sack.
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

[QuestScript(40090)]
public class Quest40090Script : QuestScript
{
	protected override void Load()
	{
		SetId(40090);
		SetName("Working on the Landfill (3)");
		SetDescription("Check out the suspicious sack");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_4_SQ_030_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("FARM47_4_SQ_020"));

		AddDialogHook("FARM47_DOWN_SACK_D", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JAUNIUS", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("FARM47_4_SQ_030_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FARM47_4_SQ_040");
	}
}

