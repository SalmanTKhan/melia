//--- Melia Script -----------------------------------------------------------
// Cross the Threshold
//--- Description -----------------------------------------------------------
// Quest to Complete [Goddess: Delmore Battlefield].
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

[QuestScript(91127)]
public class Quest91127Script : QuestScript
{
	protected override void Load()
	{
		SetId(91127);
		SetName("Cross the Threshold");
		SetDescription("Complete [Goddess: Delmore Battlefield]");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_F_CASTLE_5_RAID_1"));

		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP14_F_CASTLE_5_RAID_2_CNPC_DLG1");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		dialog.HideNPC("EP14_1_FCASTLE5_MQ_8_NPC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

