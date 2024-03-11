//--- Melia Script -----------------------------------------------------------
// White Witch Forest
//--- Description -----------------------------------------------------------
// Quest to Talk to Crusader Master.
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

[QuestScript(91007)]
public class Quest91007Script : QuestScript
{
	protected override void Load()
	{
		SetId(91007);
		SetName("White Witch Forest");
		SetDescription("Talk to Crusader Master");

		AddPrerequisite(new LevelPrerequisite(440));

		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG01", "F_TABLELAND_28_2_RAID_01", "I can help.", "I can't help you."))
		{
			case 1:
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG02");
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

		await dialog.Msg("F_TABLELAND_28_2_RAID_DLG03");
		dialog.UnHideNPC("UNIQUE_RAID_GLACIER_PORTAL");
		dialog.UnHideNPC("LEGEND_RAID_GLACIER_PORTAL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

