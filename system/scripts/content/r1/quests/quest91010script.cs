//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Crusader Envoy.
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

[QuestScript(91010)]
public class Quest91010Script : QuestScript
{
	protected override void Load()
	{
		SetId(91010);
		SetName("White Witch and the Crusader(3)");
		SetDescription("Talk to Crusader Envoy");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_03"));

		AddDialogHook("NPC_CRUSADER_01", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG11", "F_TABLELAND_28_2_RAID_04", "Tell him you will go there", "I don't want to be involved anymore."))
		{
			case 1:
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG12");
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

		await dialog.Msg("F_TABLELAND_28_2_RAID_DLG15");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

