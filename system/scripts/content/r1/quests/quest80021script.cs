//--- Melia Script -----------------------------------------------------------
// The Mysterious Girl (2)
//--- Description -----------------------------------------------------------
// Quest to Meeting with the mysterious girl.
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

[QuestScript(80021)]
public class Quest80021Script : QuestScript
{
	protected override void Load()
	{
		SetId(80021);
		SetName("The Mysterious Girl (2)");
		SetDescription("Meeting with the mysterious girl");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_323_MQ_04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_03"));

		AddDialogHook("ORCHARD323_MAYOR", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_323_MQ_05");
	}
}

