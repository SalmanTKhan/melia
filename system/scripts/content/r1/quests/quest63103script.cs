//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Illusion of the Girl .
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

[QuestScript(63103)]
public class Quest63103Script : QuestScript
{
	protected override void Load()
	{
		SetId(63103);
		SetName("Revelator of Moroth (2)");
		SetDescription("Talk to Illusion of the Girl ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_3LINE_TUTO_MQ_2_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_1_2"));

		AddObjective("kill0", "Kill 4 Banshee(s)", new KillObjective(4, MonsterId.Banshee));

		AddDialogHook("EP14_MULIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_RAMIN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_3LINE_TUTO_MQ_2_1", "EP14_3LINE_TUTO_MQ_2", "I am ready", "Wait for a while"))
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

		await dialog.Msg("EP14_3LINE_TUTO_MQ_2_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_3");
	}
}

