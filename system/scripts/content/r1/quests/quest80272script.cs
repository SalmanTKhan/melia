//--- Melia Script -----------------------------------------------------------
// Lydia Schafeen's Relic (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Lehon.
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

[QuestScript(80272)]
public class Quest80272Script : QuestScript
{
	protected override void Load()
	{
		SetId(80272);
		SetName("Lydia Schafeen's Relic (5)");
		SetDescription("Talk to Resistance Adjutant Lehon");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_86_MQ_13_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_12"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_12_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_13_ST", "F_3CMLAKE_86_MQ_13", "Okay.", "Sorry, I'll have to refuse."))
		{
			case 1:
				dialog.HideNPC("F_3CMLAKE_86_MQ_12_NPC");
				await Task.Delay(500);
				// Func/SCR_F_3CMLAKE_86_MQ_10_RUNNPC;
				dialog.UnHideNPC("F_3CMLAKE_86_FOLLOWER");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

