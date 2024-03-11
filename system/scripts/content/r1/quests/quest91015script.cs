//--- Melia Script -----------------------------------------------------------
// Abnormal Severe Cold Wave of Stogas Plateau 
//--- Description -----------------------------------------------------------
// Quest to Find Crusader Envoy..
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

[QuestScript(91015)]
public class Quest91015Script : QuestScript
{
	protected override void Load()
	{
		SetId(91015);
		SetName("Abnormal Severe Cold Wave of Stogas Plateau ");
		SetDescription("Find Crusader Envoy.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GLACIER_RAID_TUTO_RP_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_01"));

		AddReward(new ItemReward("Ability_Point_Stone", 5));

		AddDialogHook("NPC_CRUSADER_02", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_CRUSADER_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GLACIER_TUTO_RP_DLG_01", "GLACIER_RAID_TUTO_RP_01", "Help with the investigation.", "Don't help with the investigation."))
		{
			case 1:
				await dialog.Msg("GLACIER_TUTO_RP_DLG_02");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("GLACIER_TUTO_RP_DLG_04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

