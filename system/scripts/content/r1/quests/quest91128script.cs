//--- Melia Script -----------------------------------------------------------
// The Missing People
//--- Description -----------------------------------------------------------
// Quest to Find the Orsha Port Entry Officer.
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

[QuestScript(91128)]
public class Quest91128Script : QuestScript
{
	protected override void Load()
	{
		SetId(91128);
		SetName("The Missing People");
		SetDescription("Find the Orsha Port Entry Officer");

		AddPrerequisite(new LevelPrerequisite(470));

		AddDialogHook("EP14_F_CORAL_RAID_1_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_F_CORAL_RAID_1_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_F_CORAL_RAID_1_SNPC_DLG1", "EP14_F_CORAL_RAID_1", "I will help the search", "Not my business"))
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

		await dialog.Msg("EP14_F_CORAL_RAID_1_CNPC_DLG1");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_F_CORAL_RAID_2");
	}
}

