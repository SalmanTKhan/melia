//--- Melia Script -----------------------------------------------------------
// The Evil Monster (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Bern.
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

[QuestScript(80251)]
public class Quest80251Script : QuestScript
{
	protected override void Load()
	{
		SetId(80251);
		SetName("The Evil Monster (3)");
		SetDescription("Talk to Resistance Adjutant Bern");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_85_MQ_09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_08_1"));

		AddObjective("kill0", "Kill 1 Hydra", new KillObjective(1, MonsterId.Boss_Hydra_Q2));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_10_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_09_ST", "F_3CMLAKE_85_MQ_09", "I'll get going right away.", "I'm too afraid."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_09_AFST");
				dialog.UnHideNPC("F_3CMLAKE_85_MQ_10_NPC");
				dialog.UnHideNPC("F_3CMLAKE_85_MQ_10_NPC1");
				dialog.UnHideNPC("F_3CMLAKE_85_MQ_10_NPC2");
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

		await dialog.Msg("F_3CMLAKE_85_MQ_09_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

