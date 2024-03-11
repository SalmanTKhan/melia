//--- Melia Script -----------------------------------------------------------
// Adventurer's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adventurer Varkis.
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

[QuestScript(1059)]
public class Quest1059Script : QuestScript
{
	protected override void Load()
	{
		SetId(1059);
		SetName("Adventurer's Favor (2)");
		SetDescription("Talk to Adventurer Varkis");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "ROKAS29_VACYS2_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(73));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS1"));

		AddObjective("kill0", "Kill 1 Lithorex", new KillObjective(1, MonsterId.Boss_Lithorex_Q1));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("VACYS_LIVE_ENTER", "BeforeStart", BeforeStart);
		AddDialogHook("VACYS_LIVE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS29_VACYS2_succ1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Unfortunately, Varkis passed away...{nl}Take his Research Materials to Camp of Varkis");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("VACYS_LIVE");
		dialog.UnHideNPC("VACYS_SOUL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

