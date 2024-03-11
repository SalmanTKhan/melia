//--- Melia Script -----------------------------------------------------------
// Medeina's Traces (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Astra.
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

[QuestScript(80416)]
public class Quest80416Script : QuestScript
{
	protected override void Load()
	{
		SetId(80416);
		SetName("Medeina's Traces (4)");
		SetDescription("Talk to Kupole Astra");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_MAPLE_24_3_MQ_09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(408));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_3_MQ_08"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23256));

		AddDialogHook("F_MAPLE_243_MQ_08_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_243_MQ_10_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_3_MQ_09_ST", "F_MAPLE_24_3_MQ_09", "Let's get going.", "Let's rest for while."))
		{
			case 1:
				await dialog.Msg("F_MAPLE_24_3_MQ_09_AFST");
				dialog.HideNPC("F_MAPLE_243_MQ_08_NPC");
				await dialog.Msg("FadeOutIN/1000");
				// Func/SCR_F_MAPLE_243_MQ_09_RUNNPC;
				// Func/F_MAPLE_243_MQ_09_START_RUN;
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

		await dialog.Msg("F_MAPLE_24_3_MQ_09_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

