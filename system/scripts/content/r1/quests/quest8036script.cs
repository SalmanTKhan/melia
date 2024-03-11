//--- Melia Script -----------------------------------------------------------
// The Stone Pillar at Overlong Bridge Valley
//--- Description -----------------------------------------------------------
// Quest to The Stone Pillar at Overlong Bridge Valley.
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

[QuestScript(8036)]
public class Quest8036Script : QuestScript
{
	protected override void Load()
	{
		SetId(8036);
		SetName("The Stone Pillar at Overlong Bridge Valley");
		SetDescription("The Stone Pillar at Overlong Bridge Valley");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS26_QUEST05_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("collect0", "Collect 1 Small Stone Piece", new CollectItemObjective("ROKAS26_M_SLATE4", 1));
		AddDrop("ROKAS26_M_SLATE4", 10f, "boss_Shnayim");

		AddObjective("kill0", "Kill 1 Shnayim", new KillObjective(1, MonsterId.Boss_Shnayim));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_QUEST05_STONE", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

