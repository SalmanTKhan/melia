//--- Melia Script -----------------------------------------------------------
// Zealot's Trial
//--- Description -----------------------------------------------------------
// Quest to Talk with the Zealot Master.
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

[QuestScript(90223)]
public class Quest90223Script : QuestScript
{
	protected override void Load()
	{
		SetId(90223);
		SetName("Zealot's Trial");
		SetDescription("Talk with the Zealot Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_ZEALOT_QUEST_COSTUME_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("ZEALOT_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("ZEALOT_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ZEALOT_QUEST_COSTUME_ST", "JOB_ZEALOT_QUEST_COSTUME", "I will challenge the trail", "Let me prepare"))
		{
			case 1:
				await dialog.Msg("JOB_ZEALOT_QUEST_COSTUME_AG");
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

		await dialog.Msg("JOB_ZEALOT_QUEST_COSTUME_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

