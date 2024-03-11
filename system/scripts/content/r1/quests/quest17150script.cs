//--- Melia Script -----------------------------------------------------------
// Tyrant of the Srautas Gorge
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Matthew.
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

[QuestScript(17150)]
public class Quest17150Script : QuestScript
{
	protected override void Load()
	{
		SetId(17150);
		SetName("Tyrant of the Srautas Gorge");
		SetDescription("Talk to Watcher Matthew");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE571_MQ_05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(26));

		AddObjective("kill0", "Kill 1 Poata", new KillObjective(1, MonsterId.Boss_Poata_Q1));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 364));

		AddDialogHook("GELE571_NPC_MATTHEW", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_MATTHEW", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE571_MQ_06_01", "GELE571_MQ_06", "I'll go and hunt the Poata", "About the cable car", "Don't worry. That will never happen"))
		{
			case 1:
				dialog.UnHideNPC("GELE571_MQ_05");
				await dialog.Msg("GELE571_MQ_06_AG");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("GELE571_MQ_06_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("GELE571_SAM_AFTER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

