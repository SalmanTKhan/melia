//--- Melia Script -----------------------------------------------------------
// Trustworthy
//--- Description -----------------------------------------------------------
// Quest to Talk to Jamelhan.
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

[QuestScript(50157)]
public class Quest50157Script : QuestScript
{
	protected override void Load()
	{
		SetId(50157);
		SetName("Trustworthy");
		SetDescription("Talk to Jamelhan");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_71_SQ1_TRACK", "boss_b");

		AddPrerequisite(new LevelPrerequisite(242));

		AddObjective("kill0", "Kill 1 Yeti", new KillObjective(1, MonsterId.Boss_Yeti_Q1));

		AddReward(new ExpReward(8865549, 8865549));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 8954));

		AddDialogHook("TABLE71_PEAPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ1_startnpc01", "TABLELAND_71_SQ1", "Ask what's going on", "I don't know what you're talking about."))
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

		await dialog.Msg("TABLELAND_71_SQ1_succ01");
		character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
		await dialog.Msg("TABLE71_SELECTDIALOG1");
		await dialog.Msg("맞다고 한다");
		await dialog.Msg("TABLELAND_71_SQ1_succ02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

