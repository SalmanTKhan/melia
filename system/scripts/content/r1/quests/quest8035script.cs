//--- Melia Script -----------------------------------------------------------
// The Stone Pillar Above Alkune Stairway
//--- Description -----------------------------------------------------------
// Quest to The Stone Pillar Above Alkune Stairway.
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

[QuestScript(8035)]
public class Quest8035Script : QuestScript
{
	protected override void Load()
	{
		SetId(8035);
		SetName("The Stone Pillar Above Alkune Stairway");
		SetDescription("The Stone Pillar Above Alkune Stairway");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS26_QUEST04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 21 Dumaro(s) or Wendigo(s)", new KillObjective(21, 57038, 41446));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("ROKAS26_M_SLATE3", 1));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_QUEST04_STONE", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_QUEST04_STONE", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}
}

