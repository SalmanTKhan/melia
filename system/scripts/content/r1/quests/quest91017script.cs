//--- Melia Script -----------------------------------------------------------
// White Witch and the Crusader(9)
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

[QuestScript(91017)]
public class Quest91017Script : QuestScript
{
	protected override void Load()
	{
		SetId(91017);
		SetName("White Witch and the Crusader(9)");
		SetDescription("Talk to Crusader Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_TABLELAND_28_2_RAID_10_TRACK01", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_09"));

		AddReward(new ItemReward("expCard17", 2));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CRUSADER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_TABLELAND_28_2_RAID_DLG34", "F_TABLELAND_28_2_RAID_10", "I'd be prepared.", "Tell him to go there later"))
		{
			case 1:
				await dialog.Msg("F_TABLELAND_28_2_RAID_DLG35");
				dialog.UnHideNPC("F_TABLELAND_28_2_RAID_10_NPC_06");
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

		await dialog.Msg("F_TABLELAND_28_2_RAID_DLG37");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_TABLELAND_28_2_RAID_11");
	}
}

