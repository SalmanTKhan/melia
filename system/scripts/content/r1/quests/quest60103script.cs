//--- Melia Script -----------------------------------------------------------
// Large-Scale Search Operation (5)
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Sendal.
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

[QuestScript(60103)]
public class Quest60103Script : QuestScript
{
	protected override void Load()
	{
		SetId(60103);
		SetName("Large-Scale Search Operation (5)");
		SetDescription("Talk with Chaser Sendal");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU11RE_MQ_05_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_04"));

		AddObjective("kill0", "Kill 1 Specter Monarch", new KillObjective(1, MonsterId.Boss_Spector_M_Q1));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 169));
		AddReward(new ItemReward("TreasureboxKey2", 1));

		AddDialogHook("SIAULIAI11RE_SENDAL", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_PRANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_MQ_05_01", "SIAU11RE_MQ_05", "I'll save the day", "I am not ready yet"))
		{
			case 1:
				dialog.HideNPC("SIAU11RE_MQ_06_NPC");
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


		return HookResult.Break;
	}
}

