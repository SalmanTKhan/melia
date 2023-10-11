//--- Melia Script -----------------------------------------------------------
// Capturing Bramble (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Jurga.
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

[QuestScript(20274)]
public class Quest20274Script : QuestScript
{
	protected override void Load()
	{
		SetId(20274);
		SetName("Capturing Bramble (3)");
		SetDescription("Talk to Believer Jurga");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN21_MQ07_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("THORN21_MQ09"));

		AddObjective("kill0", "Kill 1 Bramble", new KillObjective(1, MonsterId.Boss_Bramble));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("misc_NECK03_104_3", 1));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BELIEVER04_AFTER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN21_MQ07_select01", "THORN21_MQ07", "I'll defeat Bramble and retrieve the revelation", "Give me some time to prepare"))
		{
			case 1:
				await dialog.Msg("THORN21_MQ07_startnpc01");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN21_MQ08");
	}
}

