//--- Melia Script -----------------------------------------------------------
// The Stone Pillar Beneath Alkune Stairway
//--- Description -----------------------------------------------------------
// Quest to The Stone Pillar Beneath Alkune Stairway.
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

[QuestScript(8034)]
public class Quest8034Script : QuestScript
{
	protected override void Load()
	{
		SetId(8034);
		SetName("The Stone Pillar Beneath Alkune Stairway");
		SetDescription("The Stone Pillar Beneath Alkune Stairway");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS26_QUEST03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("collect0", "Collect 3 Old Pillar Sculpture(s)", new CollectItemObjective("ROKAS26_M_SLATE2", 3));
		AddDrop("ROKAS26_M_SLATE2", 10f, "npc_rokas_7");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_QUEST03_STONE", "BeforeStart", BeforeStart);
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

