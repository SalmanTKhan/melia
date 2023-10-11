//--- Melia Script -----------------------------------------------------------
// Scream of the Soul
//--- Description -----------------------------------------------------------
// Quest to Talk to the Lord's Guard of Orsha.
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

[QuestScript(91188)]
public class Quest91188Script : QuestScript
{
	protected override void Load()
	{
		SetId(91188);
		SetName("Scream of the Soul");
		SetDescription("Talk to the Lord's Guard of Orsha");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_6"));

		AddDialogHook("C_ORSHA_SOLDIER_01", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_EP15_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("RAID_ABBEY_EP15_1_MQ_1_DLG1", "RAID_ABBEY_EP15_1_MQ_1", "Ask what's going on.", "I'm a bit busy so let's talk later."))
		{
			case 1:
				await dialog.Msg("RAID_ABBEY_EP15_1_MQ_1_DLG2");
				dialog.UnHideNPC("Raid_EP15_1_NPC");
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

		await dialog.Msg("RAID_ABBEY_EP15_1_MQ_1_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("RAID_ABBEY_EP15_1_MQ_2");
	}
}

