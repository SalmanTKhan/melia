//--- Melia Script -----------------------------------------------------------
// Astral Tracing (5)
//--- Description -----------------------------------------------------------
// Quest to Finding the Last Gravestone.
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

[QuestScript(20212)]
public class Quest20212Script : QuestScript
{
	protected override void Load()
	{
		SetId(20212);
		SetName("Astral Tracing (5)");
		SetDescription("Finding the Last Gravestone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAIN38_MQ05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(99));
		AddPrerequisite(new CompletedPrerequisite("REMAIN38_MQ04"));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(1, MonsterId.Boss_Chapparition_Q2));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 27720));

		AddDialogHook("REMAIN38_MQ_MONUMENT5", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_HUNTER", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Defeat Chapparitions that are disturbing when you are checking the tombstone{nl}Check what was written on the last tombstone of Lydia Schaffen");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAIN38_MQ06");
	}
}

