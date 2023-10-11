//--- Melia Script -----------------------------------------------------------
// Oratory Search (1)
//--- Description -----------------------------------------------------------
// Quest to Follow Edmundas.
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

[QuestScript(91182)]
public class Quest91182Script : QuestScript
{
	protected override void Load()
	{
		SetId(91182);
		SetName("Oratory Search (1)");
		SetDescription("Follow Edmundas");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP15_1_F_ABBEY3_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(487));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_8"));

		AddObjective("kill0", "Kill 6 Vubbe Warrior(s) or Vubbe Shaman(s)", new KillObjective(6, 59780, 59778));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_F_ABBEY3_1_TRIGGER", "BeforeStart", BeforeStart);
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

