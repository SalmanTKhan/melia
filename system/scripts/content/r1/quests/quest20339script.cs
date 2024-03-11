//--- Melia Script -----------------------------------------------------------
// Masquerade
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Goda.
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

[QuestScript(20339)]
public class Quest20339Script : QuestScript
{
	protected override void Load()
	{
		SetId(20339);
		SetName("Masquerade");
		SetDescription("Talk to Priest Goda");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL56_SQ03_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(145));

		AddObjective("kill0", "Kill 1 Linkroller", new KillObjective(1, MonsterId.Boss_RingCrawler));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56_SQ03", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56_SQ03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_SQ03_select01", "CHATHEDRAL56_SQ03", "I will investigate it", "I'm busy"))
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

		await dialog.Msg("CHATHEDRAL56_SQ03_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

