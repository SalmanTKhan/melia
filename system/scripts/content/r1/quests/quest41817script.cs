//--- Melia Script -----------------------------------------------------------
// Take Down the Demons
//--- Description -----------------------------------------------------------
// Quest to Talk to the Recovery Squad Adjutant.
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

[QuestScript(41817)]
public class Quest41817Script : QuestScript
{
	protected override void Load()
	{
		SetId(41817);
		SetName("Take Down the Demons");
		SetDescription("Talk to the Recovery Squad Adjutant");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_27_1_SQ_7_TRACK1", "None");

		AddPrerequisite(new LevelPrerequisite(388));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_1_SQ_6"));

		AddObjective("kill0", "Kill 10 Amphibigola(s) or Amacalf(s)", new KillObjective(10, 59216, 59229));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_1_NPC2_3", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC2_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_1_SQ_7_DLG1", "F_3CMLAKE_27_1_SQ_7", "I'm ready.", "I need some time to prepare."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_1_SQ_7_DLG2");
				dialog.HideNPC("F_3CMLAKE_27_1_NPC2_3");
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

		await dialog.Msg("F_3CMLAKE_27_1_SQ_7_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_1_SQ_8");
	}
}

