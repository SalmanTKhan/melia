//--- Melia Script -----------------------------------------------------------
// For Total Freedom (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elgos Abbot.
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

[QuestScript(80095)]
public class Quest80095Script : QuestScript
{
	protected override void Load()
	{
		SetId(80095);
		SetName("For Total Freedom (1)");
		SetDescription("Talk to the Elgos Abbot");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY_35_4_SQ_7_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_6"));

		AddObjective("kill0", "Kill 1 Glutton", new KillObjective(1, MonsterId.Boss_Glutton_Q1));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_ELDER", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_ELDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_4_SQ_7_start", "ABBEY_35_4_SQ_7", "I will certainly help", "Please wait little more"))
		{
			case 1:
				await dialog.Msg("ABBEY_35_4_SQ_7_add");
				dialog.UnHideNPC("ABBEY_35_4_DOMINIKAS");
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

		await dialog.Msg("ABBEY_35_4_SQ_7_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

