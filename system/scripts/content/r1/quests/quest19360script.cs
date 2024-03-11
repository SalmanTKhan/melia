//--- Melia Script -----------------------------------------------------------
// Activate the Tzedej Altar
//--- Description -----------------------------------------------------------
// Quest to Tzedej Altar.
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

[QuestScript(19360)]
public class Quest19360Script : QuestScript
{
	protected override void Load()
	{
		SetId(19360);
		SetName("Activate the Tzedej Altar");
		SetDescription("Tzedej Altar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS30_MQ6_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 5 Hogma Fighter(s) or Hogma Scout(s) or Hogma Captain(s) or Hogma Archer(s) or Hogma Shaman(s)", new KillObjective(5, 47308, 47309, 41441, 41434, 41435));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("ROKAS30_SEALDESTROY2", "BeforeStart", BeforeStart);
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

