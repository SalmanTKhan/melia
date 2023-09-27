//--- Melia Script -----------------------------------------------------------
// Sign of Turbulent
//--- Description -----------------------------------------------------------
// Quest to Talk to Inesa Hamondale.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;
using Melia.Shared.Tos.Const;

[QuestScript(91161)]
public class Quest91161Script : QuestScript
{
	protected override void Load()
	{
		SetId(91161);
		SetName("Sign of Turbulent");
		SetDescription("Talk to Inesa Hamondale");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_6"));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_CASTLE_EP14_2_SOLD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("RAID_CASTLE_EP14_2_MQ_1_DLG1", "RAID_CASTLE_EP14_2_MQ_1", "Tell about what happened.", "I need to prepare myself."))
		{
			case 1:
				await dialog.Msg("RAID_CASTLE_EP14_2_MQ_1_DLG2");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("RAID_CASTLE_EP14_2_MQ_1_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("RAID_CASTLE_EP14_2_MQ_2");
	}
}

