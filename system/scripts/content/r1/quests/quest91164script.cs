//--- Melia Script -----------------------------------------------------------
// Mysterious Monster: Falouros
//--- Description -----------------------------------------------------------
// Quest to Talk to Orsha Investigator.
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

[QuestScript(91164)]
public class Quest91164Script : QuestScript
{
	protected override void Load()
	{
		SetId(91164);
		SetName("Mysterious Monster: Falouros");
		SetDescription("Talk to Orsha Investigator");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("RAID_CASTLE_EP14_2_MQ_2"));

		AddDialogHook("RAID_CASTLE_EP14_2_FSOLD", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_CASTLE_EP14_2_FSOLD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("RAID_CASTLE_EP14_2_MQ_3_DLG1", "RAID_CASTLE_EP14_2_MQ_3", "Alright", "I will come after doing something else."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("RAID_CASTLE_EP14_2_MQ_3_DLG3");
		await dialog.Msg("FadeOutIN/2500");
		dialog.HideNPC("RAID_CASTLE_EP14_2_FSOLD");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

