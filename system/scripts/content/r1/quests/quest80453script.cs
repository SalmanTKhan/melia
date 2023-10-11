//--- Melia Script -----------------------------------------------------------
// Baiga's Offer
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon King Baiga.
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

[QuestScript(80453)]
public class Quest80453Script : QuestScript
{
	protected override void Load()
	{
		SetId(80453);
		SetName("Baiga's Offer");
		SetDescription("Talk to Demon King Baiga");
		SetTrack(QuestStatus.Possible, QuestStatus.Possible, "F_CASTLE_97_MQ_05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(426));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_97_MQ_04"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("F_CASTLE_97_MQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_97_MQ_05_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_CASTLE_97_MQ_05_ST", "F_CASTLE_97_MQ_05", "Ask what he wants.", "Leave."))
		{
			case 1:
				dialog.HideNPC("F_CASTLE_97_MQ_05_NPC");
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

		await dialog.Msg("F_CASTLE_97_MQ_05_SU");
		dialog.HideNPC("F_CASTLE_97_MQ_05_NPC2");
		dialog.UnHideNPC("F_CASTLE_99_MQ_01_NPC");
		await dialog.Msg("FadeOutIN/2000");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

