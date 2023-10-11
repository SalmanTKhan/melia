//--- Melia Script -----------------------------------------------------------
// Fantasy of the Watcher (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Molly.
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

[QuestScript(17160)]
public class Quest17160Script : QuestScript
{
	protected override void Load()
	{
		SetId(17160);
		SetName("Fantasy of the Watcher (2)");
		SetDescription("Talk to Watcher Molly");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE571_MQ_07_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(26));
		AddPrerequisite(new CompletedPrerequisite("GELE571_MQ_04"));

		AddObjective("kill0", "Kill 1 Capria", new KillObjective(1, MonsterId.Boss_Capria));

		AddReward(new ExpReward(40290, 40290));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("HAND02_117", 1));
		AddReward(new ItemReward("Vis", 2548));

		AddDialogHook("GELE571_NPC_MARLEY", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_MARLEY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE571_MQ_07_01", "GELE571_MQ_07", "I'm not sure but I'll give it a shot", "About the Capri", "Seems like a dangerous plan"))
		{
			case 1:
				// Func/GELE571_MQ_08_FOLLOWER;
				dialog.UnHideNPC("GELE571_MQ_07");
				dialog.UnHideNPC("GELE571_MQ_07_1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("GELE571_MQ_07_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("GELE571_MQ_07_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

