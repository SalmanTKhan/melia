//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (4)
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

[QuestScript(63106)]
public class Quest63106Script : QuestScript
{
	protected override void Load()
	{
		SetId(63106);
		SetName("Revelator of Moroth (4)");
		SetDescription("Talk to Illusion of the Girl ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_3LINE_TUTO_MQ_4_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_3_1"));

		AddDialogHook("EP14_MULIA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_KAONEELA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_3LINE_TUTO_MQ_4_1", "EP14_3LINE_TUTO_MQ_4", "Alright", "You're irresponsible"))
		{
			case 1:
				dialog.HideNPC("EP14_3LINE_TUTO_MQ_4_GATE");
				// Func/SCR_EP14_TUTO_SHOWHELP_MAP;
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

		await dialog.Msg("EP14_3LINE_TUTO_MQ_4_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_5");
	}
}

