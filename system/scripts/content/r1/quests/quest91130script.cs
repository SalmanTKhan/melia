//--- Melia Script -----------------------------------------------------------
// Those Named Nijole (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Nijole at Fasika Plateau.
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

[QuestScript(91130)]
public class Quest91130Script : QuestScript
{
	protected override void Load()
	{
		SetId(91130);
		SetName("Those Named Nijole (2)");
		SetDescription("Talk to Nijole at Fasika Plateau");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_F_CORAL_RAID_2"));

		AddDialogHook("PILGRIM_36_2_NIJOLE", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_F_CORAL_RAID_3_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_F_CORAL_RAID_3_SNPC_DLG1", "EP14_F_CORAL_RAID_3", "I'm sorry for suspecting you", "(Keep Silent)"))
		{
			case 1:
				dialog.UnHideNPC("EP14_F_CORAL_RAID_3_NPC_1");
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

		await dialog.Msg("EP14_F_CORAL_RAID_3_CNPC_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

