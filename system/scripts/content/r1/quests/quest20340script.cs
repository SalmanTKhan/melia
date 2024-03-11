//--- Melia Script -----------------------------------------------------------
// The Bishop's Last Mission (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20340)]
public class Quest20340Script : QuestScript
{
	protected override void Load()
	{
		SetId(20340);
		SetName("The Bishop's Last Mission (1)");
		SetDescription("Talk to Bishop Aurelius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL54_MQ05_PART3_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ08"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 11));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56_MQ_BISHOP_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("MQ05_PROOF_PRIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_MQ05_PART3_select01", "CHATHEDRAL54_MQ05_PART3", "Go to test the last verification", "Take some time to prepare"))
		{
			case 1:
				ZoneServer.Instance.World.FindNPC("CHATHEDRAL56_MQ_BISHOP_AFTER")?.PlayEffectLocal(character.Connection, "F_cleric_resurrection_shot", 1f, "BOT");
				dialog.HideNPC("CHATHEDRAL56_MQ_BISHOP_AFTER");
				await dialog.Msg("CHATHEDRAL54_MQ05_PART3_AG");
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

		dialog.HideNPC("CATHEDRAL54_HIDDEN_WALL");
		await dialog.Msg("NPCAin/CHATHEDRAL_GATE_NPC/astd/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

