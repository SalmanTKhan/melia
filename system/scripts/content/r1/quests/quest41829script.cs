//--- Melia Script -----------------------------------------------------------
// Monster Leader Operation (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Brockal Himil's Apprentice.
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

[QuestScript(41829)]
public class Quest41829Script : QuestScript
{
	protected override void Load()
	{
		SetId(41829);
		SetName("Monster Leader Operation (3)");
		SetDescription("Talk to Brockal Himil's Apprentice");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_3CMLAKE_27_2_SQ_8_TRACK1", "None");

		AddPrerequisite(new LevelPrerequisite(391));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_2_SQ_7"));

		AddObjective("kill0", "Kill 1 Devious Moldyhorn", new KillObjective(1, MonsterId.Boss_Moldyhorn_3cmlake_27_2));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_2_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_2_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_2_SQ_8_DLG1", "F_3CMLAKE_27_2_SQ_8", "I'll head to the standby location right away.", "Let me just check the bombs one more time."))
		{
			case 1:
				dialog.HideNPC("F_3CMLAKE_27_2_NPC3");
				dialog.UnHideNPC("F_3CMLAKE_27_2_NPC4");
				dialog.HideNPC("F_3CMLAKE_27_2_SQ_7_HNPC4");
				dialog.HideNPC("F_3CMLAKE_27_2_SQ_7_HNPC5");
				dialog.HideNPC("F_3CMLAKE_27_2_SQ_7_HNPC6");
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

		await dialog.Msg("F_3CMLAKE_27_2_SQ_8_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

