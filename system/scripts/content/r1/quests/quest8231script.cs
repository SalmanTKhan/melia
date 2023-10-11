//--- Melia Script -----------------------------------------------------------
// Remote Area of Kateen Forest
//--- Description -----------------------------------------------------------
// Quest to Talk with the Scouts.
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

[QuestScript(8231)]
public class Quest8231Script : QuestScript
{
	protected override void Load()
	{
		SetId(8231);
		SetName("Remote Area of Kateen Forest");
		SetDescription("Talk with the Scouts");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN71_BOSS_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(107));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(1, MonsterId.Boss_Deadbone));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("TreasureboxKey3", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("KATYN71_BOSS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN71_MQ_07", "KATYN71_MQ_07", "Alright, I'll help you", "Calm down. It can't be a Deadborn"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

