//--- Melia Script -----------------------------------------------------------
// Adapting to Circumstances (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20332)]
public class Quest20332Script : QuestScript
{
	protected override void Load()
	{
		SetId(20332);
		SetName("Adapting to Circumstances (5)");
		SetDescription("Talk to Bishop Aurelius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL56_MQ04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ03"));

		AddObjective("kill0", "Kill 7 Blue Pawndel(s) or Black Pawnd(s)", new KillObjective(7, 57371, 57370));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_MQ04_select01", "CHATHEDRAL56_MQ04", "Tell him to go to Apgaule Altar", "Decline"))
		{
			case 1:
				await dialog.Msg("CHATHEDRAL56_MQ04_AG");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

