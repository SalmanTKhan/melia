//--- Melia Script -----------------------------------------------------------
// Saint's Sacellum
//--- Description -----------------------------------------------------------
// Quest to Listen to a rumor about the Saint's Sacellum from the Chaplain master.
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

[QuestScript(91083)]
public class Quest91083Script : QuestScript
{
	protected override void Load()
	{
		SetId(91083);
		SetName("Saint's Sacellum");
		SetDescription("Listen to a rumor about the Saint's Sacellum from the Chaplain master");

		AddPrerequisite(new LevelPrerequisite(460));

		AddDialogHook("CHAPLAIN_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARBALESTER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_RAID_1_DLG_1", "EP13_F_SIAULIAI_RAID_1", "Alright", "Ask more about the Saint's Sacellum", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_RAID_1_DLG_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("EP13_F_SIAULIAI_RAID_1_DLG_4");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP13_F_SIAULIAI_RAID_1_DLG_3");
		dialog.UnHideNPC("GODDESS_RAID_VASILISSA_PORTAL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

