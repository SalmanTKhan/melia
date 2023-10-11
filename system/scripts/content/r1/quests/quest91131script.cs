//--- Melia Script -----------------------------------------------------------
// Those Named Nijole (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Nijole at Gateway of the Great King.
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

[QuestScript(91131)]
public class Quest91131Script : QuestScript
{
	protected override void Load()
	{
		SetId(91131);
		SetName("Those Named Nijole (3)");
		SetDescription("Talk to Nijole at Gateway of the Great King");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_F_CORAL_RAID_3"));

		AddDialogHook("EP14_F_CORAL_RAID_3_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_F_CORAL_RAID_4_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_F_CORAL_RAID_4_SNPC_DLG1", "EP14_F_CORAL_RAID_4", "Alright", "(Keep Silent)"))
		{
			case 1:
				dialog.UnHideNPC("EP14_F_CORAL_RAID_4_NPC_1");
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

		await dialog.Msg("EP14_F_CORAL_RAID_4_CNPC_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

