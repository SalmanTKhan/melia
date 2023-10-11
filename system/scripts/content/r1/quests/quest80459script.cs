//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Austeja.
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

[QuestScript(80459)]
public class Quest80459Script : QuestScript
{
	protected override void Load()
	{
		SetId(80459);
		SetName("Root of the Divine Tree (6)");
		SetDescription("Talk to Goddess Austeja");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_CASTLE_99_MQ_06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(431));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_05"));

		AddObjective("kill0", "Kill 1 Jezebel", new KillObjective(1, MonsterId.Boss_Jezebel_Q1));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));
		AddReward(new ItemReward("Vis", 24998));

		AddDialogHook("F_CASTLE_99_MQ_06_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_99_MQ_07_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_CASTLE_99_MQ_06_ST", "F_CASTLE_99_MQ_06", "Let's go.", "I'm afraid."))
		{
			case 1:
				dialog.UnHideNPC("F_CASTLE_99_MQ_07_NPC");
				dialog.UnHideNPC("F_CASTLE_99_MQ_07_NPC2");
				dialog.UnHideNPC("F_CASTLE_99_MQ_07_NPC3");
				dialog.UnHideNPC("F_CASTLE_99_MQ_07_NPC4");
				dialog.HideNPC("F_CASTLE_99_MQ_06_NPC");
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

		await dialog.Msg("F_CASTLE_99_MQ_06_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

