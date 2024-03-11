//--- Melia Script -----------------------------------------------------------
// Approval (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon King Baiga.
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

[QuestScript(80452)]
public class Quest80452Script : QuestScript
{
	protected override void Load()
	{
		SetId(80452);
		SetName("Approval (4)");
		SetDescription("Talk to Demon King Baiga");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_CASTLE_97_MQ_04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(426));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_97_MQ_03"));

		AddObjective("kill0", "Kill 1 Velnipper", new KillObjective(1, MonsterId.Boss_Velnipper_Q1));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 24708));

		AddDialogHook("F_CASTLE_97_MQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_97_MQ_05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_CASTLE_97_MQ_04_ST", "F_CASTLE_97_MQ_04", "Alright", "Give up."))
		{
			case 1:
				dialog.HideNPC("F_CASTLE_97_MQ_04_NPC");
				await dialog.Msg("FadeOutIN/2000");
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

		await dialog.Msg("F_CASTLE_97_MQ_04_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

