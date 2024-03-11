//--- Melia Script -----------------------------------------------------------
// The Outcome of Choice (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ranger Morvio.
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

[QuestScript(80293)]
public class Quest80293Script : QuestScript
{
	protected override void Load()
	{
		SetId(80293);
		SetName("The Outcome of Choice (1)");
		SetDescription("Talk to Ranger Morvio");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_87_MQ_09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_08"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_87_MQ_09_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_09_ST", "F_3CMLAKE_87_MQ_09", "We should get a move on.", "Let's rest for while."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_09_AFST");
				dialog.HideNPC("F_3CMLAKE_87_MQ_09_NPC_1");
				dialog.HideNPC("F_3CMLAKE_87_MQ_09_NPC_2");
				await dialog.Msg("FadeOutIN/1000");
				// Func/F_3CMLAKE_87_MQ_09_RUNNPC;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

