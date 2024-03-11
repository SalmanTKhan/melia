//--- Melia Script -----------------------------------------------------------
// Royal Mausoleum's Treasure
//--- Description -----------------------------------------------------------
// Quest to Examine the Royal Mausoleum Archives.
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

[QuestScript(8446)]
public class Quest8446Script : QuestScript
{
	protected override void Load()
	{
		SetId(8446);
		SetName("Royal Mausoleum's Treasure");
		SetDescription("Examine the Royal Mausoleum Archives");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA4F_SQ_05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(92));

		AddObjective("kill0", "Kill 1 Rocktortuga", new KillObjective(1, MonsterId.Boss_Rocktortuga_Q1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("TreasureboxKey2", 1));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ZACHA4F_SQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA4F_SQ_05", "ZACHA4F_SQ_05", "Challenge the spell of the Royal Mausoleum", "Pass the challenge"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

