//--- Melia Script -----------------------------------------------------------
// Lord's Advice
//--- Description -----------------------------------------------------------
// Quest to Talk to Inesa Hamondale, Lord of Orsha.
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

[QuestScript(91165)]
public class Quest91165Script : QuestScript
{
	protected override void Load()
	{
		SetId(91165);
		SetName("Lord's Advice");
		SetDescription("Talk to Inesa Hamondale, Lord of Orsha");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY1_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_6"));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY1_1_DLG1", "EP15_1_F_ABBEY1_1", "I will try praying.", "I need a moment to think."))
		{
			case 1:
				await dialog.Msg("EP15_1_F_ABBEY1_1_DLG2");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Worship the Statue of Goddess Ausrine in the Central Plaza!", 8);
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

