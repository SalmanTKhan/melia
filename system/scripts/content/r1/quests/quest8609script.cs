//--- Melia Script -----------------------------------------------------------
// Grown Apart From Hope
//--- Description -----------------------------------------------------------
// Quest to Find Follower Algis.
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

[QuestScript(8609)]
public class Quest8609Script : QuestScript
{
	protected override void Load()
	{
		SetId(8609);
		SetName("Grown Apart From Hope");
		SetDescription("Find Follower Algis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE574_MQ_09_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(35));
		AddPrerequisite(new CompletedPrerequisite("GELE573_MQ_08"));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(1, MonsterId.Boss_Chapparition));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("Vis", 4410));

		AddDialogHook("GELE574_ALLGES", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_ARUNE_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE574_MQ_09_01", "GELE574_MQ_09", "I will chase it immediately", "I'm not ready yet"))
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

		await dialog.Msg("GELE574_MQ_09_03");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The 1st floor of the Tenet Church has been sealed by Gesti's powers.{nl}Find the way to go up to the first floor through the basement!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

