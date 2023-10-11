//--- Melia Script -----------------------------------------------------------
// The Mysterious Girl (1)
//--- Description -----------------------------------------------------------
// Quest to Meeting the Mysterious Girl.
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

[QuestScript(80019)]
public class Quest80019Script : QuestScript
{
	protected override void Load()
	{
		SetId(80019);
		SetName("The Mysterious Girl (1)");
		SetDescription("Meeting the Mysterious Girl");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_323_MQ_02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_01"));

		AddDialogHook("ORCHARD323_LEJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

