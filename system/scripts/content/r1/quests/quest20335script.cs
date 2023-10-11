//--- Melia Script -----------------------------------------------------------
// The sealed door
//--- Description -----------------------------------------------------------
// Quest to Look for a way to open the sealed door.
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

[QuestScript(20335)]
public class Quest20335Script : QuestScript
{
	protected override void Load()
	{
		SetId(20335);
		SetName("The sealed door");
		SetDescription("Look for a way to open the sealed door");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL56_MQ07_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_MQ07_select01", "CATHEDRAL56_SQ04", "Accept", "Reject"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CHATHEDRAL56_MQ08");
	}
}

