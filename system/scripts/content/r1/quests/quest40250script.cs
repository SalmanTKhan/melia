//--- Melia Script -----------------------------------------------------------
// Energy Replenishment
//--- Description -----------------------------------------------------------
// Quest to Check the magic circles again.
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

[QuestScript(40250)]
public class Quest40250Script : QuestScript
{
	protected override void Load()
	{
		SetId(40250);
		SetName("Energy Replenishment");
		SetDescription("Check the magic circles again");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_3_SQ_080_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_070"));

		AddObjective("kill0", "Kill 20 Farm Ellum(s) or Farm Keposeed(s) or Orange Dandel(s) or Ashrong(s) or White Operor(s)", new KillObjective(20, 57502, 57503, 57327, 57488, 57330));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_MAGIC03", "BeforeStart", BeforeStart);
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

