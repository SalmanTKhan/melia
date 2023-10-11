//--- Melia Script -----------------------------------------------------------
// Sinking Seizure (2)
//--- Description -----------------------------------------------------------
// Quest to Return to Nijole at Igti Coast.
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

[QuestScript(91133)]
public class Quest91133Script : QuestScript
{
	protected override void Load()
	{
		SetId(91133);
		SetName("Sinking Seizure (2)");
		SetDescription("Return to Nijole at Igti Coast");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_F_CORAL_RAID_5"));

		AddDialogHook("EP14_F_CORAL_RAID_4_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_F_CORAL_RAID_6_SNPC_DLG1", "EP14_F_CORAL_RAID_6", "I'm ready", "Not yet"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP14_F_CORAL_RAID_4_NPC_1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

