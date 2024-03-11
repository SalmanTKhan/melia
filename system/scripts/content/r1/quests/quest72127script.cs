//--- Melia Script -----------------------------------------------------------
// Shadow Adaptation Training
//--- Description -----------------------------------------------------------
// Quest to Talk with the Shadowmancer Master.
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

[QuestScript(72127)]
public class Quest72127Script : QuestScript
{
	protected override void Load()
	{
		SetId(72127);
		SetName("Shadow Adaptation Training");
		SetDescription("Talk with the Shadowmancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SHADOWMANCER_Q1", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("JOB_SHADOWMANCER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SHADOWMANCER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SHADOWMANCER_Q1_DLG1", "JOB_SHADOWMANCER_Q1", "Alright", "I will train myself"))
		{
			case 1:
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

		await dialog.Msg("JOB_SHADOWMANCER_Q1_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

