//--- Melia Script -----------------------------------------------------------
// Last Warning of the Beholder
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Nojus.
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

[QuestScript(20260)]
public class Quest20260Script : QuestScript
{
	protected override void Load()
	{
		SetId(20260);
		SetName("Last Warning of the Beholder");
		SetDescription("Talk to Believer Nojus");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN19_MQ14_2", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("THORN19_BLACKMAN"));

		AddObjective("kill0", "Kill 1 Summoned Poata", new KillObjective(1, MonsterId.Boss_Poata_Q2));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("R_NECK03_104", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN_BLACKMAN_TRIGGER2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN19_MQ14_2_select01", "THORN19_MQ14_2", "I'm doing fine", "Do not go any further"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

