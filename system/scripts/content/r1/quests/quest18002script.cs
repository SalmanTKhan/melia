//--- Melia Script -----------------------------------------------------------
// Entrapped Goddess
//--- Description -----------------------------------------------------------
// Quest to Check the barrier at Saule Grand Shrine.
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

[QuestScript(18002)]
public class Quest18002Script : QuestScript
{
	protected override void Load()
	{
		SetId(18002);
		SetName("Entrapped Goddess");
		SetDescription("Check the barrier at Saule Grand Shrine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_4_MQ02_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(55));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ11"));

		AddObjective("kill0", "Kill 1 Harpeia", new KillObjective(1, MonsterId.Boss_Harpeia));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_MQ01_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("HUEVILLAGE_58_4_MQ02_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_4_MQ01");
	}
}

