//--- Melia Script -----------------------------------------------------------
// Recovery Squad in Danger
//--- Description -----------------------------------------------------------
// Quest to Saving Lives.
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

[QuestScript(41811)]
public class Quest41811Script : QuestScript
{
	protected override void Load()
	{
		SetId(41811);
		SetName("Recovery Squad in Danger");
		SetDescription("Saving Lives");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_3CMLAKE_27_1_SQ_1_TRACK1", "None");

		AddPrerequisite(new LevelPrerequisite(388));

		AddObjective("kill0", "Kill 10 Amphibigola(s)", new KillObjective(10, MonsterId.Amphibigola));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_1_SQ_1_DLG1", "F_3CMLAKE_27_1_SQ_1", "I can't ignore this.", "Sorry, I can't help."))
		{
			case 1:
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("F_3CMLAKE_27_1_SQ_1_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_1_SQ_2");
	}
}

