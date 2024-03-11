//--- Melia Script -----------------------------------------------------------
// Argument
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Zenius.
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

[QuestScript(19519)]
public class Quest19519Script : QuestScript
{
	protected override void Load()
	{
		SetId(19519);
		SetName("Argument");
		SetDescription("Talk to Pilgrim Zenius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM46_SQ_089_TRACK", 500);

		AddPrerequisite(new LevelPrerequisite(121));

		AddDialogHook("PILGRIM46_NPC04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_089_ST", "PILGRIM46_SQ_089", "Wait", "Just go your way"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

