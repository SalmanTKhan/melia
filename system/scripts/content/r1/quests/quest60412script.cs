//--- Melia Script -----------------------------------------------------------
// Different Circumstances (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tadas.
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

[QuestScript(60412)]
public class Quest60412Script : QuestScript
{
	protected override void Load()
	{
		SetId(60412);
		SetName("Different Circumstances (2)");
		SetDescription("Talk to Tadas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CASTLE96_MQ_2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE96_MQ_1"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 22857));

		AddDialogHook("CASTLE96_MQ_TADAS_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE96_MQ_TADAS_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE96_MQ_2_1", "CASTLE96_MQ_2", "Alright, but just this one time.", "Nope, I'm not convinced."))
		{
			case 1:
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

		await dialog.Msg("CASTLE96_MQ_2_3");
		// Func/SCR_CASTLE96_MQ_2_RUN_NPC_DLG_1;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

