//--- Melia Script -----------------------------------------------------------
// The Outcome of Choice (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Fletcher Voleta.
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

[QuestScript(80294)]
public class Quest80294Script : QuestScript
{
	protected override void Load()
	{
		SetId(80294);
		SetName("The Outcome of Choice (2)");
		SetDescription("Talk to Fletcher Voleta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_87_MQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_09"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19240));

		AddDialogHook("F_3CMLAKE_87_MQ_10_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_10_ST", "F_3CMLAKE_87_MQ_10", "Shoot the arrow first.", "Give me some time to think."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_10_AFST");
				dialog.HideNPC("F_3CMLAKE_87_MQ_10_NPC_1");
				// Func/SCR_F_3CMLAKE_87_MQ_10_RUNNPC;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

