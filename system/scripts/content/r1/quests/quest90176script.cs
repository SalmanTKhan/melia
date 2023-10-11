//--- Melia Script -----------------------------------------------------------
// The Eye of Demon Lord (2)
//--- Description -----------------------------------------------------------
// Quest to Check the Demon Sent by Gazing Golem.
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

[QuestScript(90176)]
public class Quest90176Script : QuestScript
{
	protected override void Load()
	{
		SetId(90176);
		SetName("The Eye of Demon Lord (2)");
		SetDescription("Check the Demon Sent by Gazing Golem");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_EYEOFBAIGA_SQ_60"));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_70_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

