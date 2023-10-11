//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60270)]
public class Quest60270Script : QuestScript
{
	protected override void Load()
	{
		SetId(60270);
		SetName("The History that Will Not Be Recorded (8)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB484_MQ_8_TRACK", "m_boss_scenario3");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_7"));

		AddObjective("kill0", "Kill 1 Lucy", new KillObjective(1, MonsterId.Boss_Lucy_Q1));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY484_NERINGA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY484_NERINGA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB484_MQ_8_1", "FANTASYLIB484_MQ_8", "I'll follow the plan", "I need to prepare"))
		{
			case 1:
				dialog.UnHideNPC("FANTASYLIB484_MQ_8_NPC");
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

		await dialog.Msg("FANTASYLIB484_MQ_8_3");
		await dialog.Msg("FadeOutIN/1500");
		dialog.HideNPC("FLIBRARY484_NERINGA_NPC_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

