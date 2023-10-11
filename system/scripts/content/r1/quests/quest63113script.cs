//--- Melia Script -----------------------------------------------------------
// [Tutorial] Combat with boss monster
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
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

[QuestScript(63113)]
public class Quest63113Script : QuestScript
{
	protected override void Load()
	{
		SetId(63113);
		SetName("[Tutorial] Combat with boss monster");
		SetDescription("Talk to Owynia Dilben");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_3LINE_TUTO_MQ_9_1_TRACk", 2000);

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_9"));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(1, MonsterId.Boss_Deadbone_J1));

		AddDialogHook("EP14_OWYNIA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_OWYNIA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_3LINE_TUTO_MQ_9_1_1", "EP14_3LINE_TUTO_MQ_9_1", "I'll find out", "It's too dangerous to do it alone"))
		{
			case 1:
				dialog.HideNPC("EP14_3LINE_TUTO_MQ_9_1_GATE");
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

		await dialog.Msg("EP14_3LINE_TUTO_MQ_9_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_10");
	}
}

