//--- Melia Script -----------------------------------------------------------
// Hogma's Treasure Chest
//--- Description -----------------------------------------------------------
// Quest to Treasure Chest of Zachariel Crossroads.
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

[QuestScript(19370)]
public class Quest19370Script : QuestScript
{
	protected override void Load()
	{
		SetId(19370);
		SetName("Hogma's Treasure Chest");
		SetDescription("Treasure Chest of Zachariel Crossroads");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS31_SUB_01_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(78));

		AddObjective("kill0", "Kill 20 Hogma Warrior(s) or Hogma Archer(s) or Hogma Shaman(s) or Hogma Captain(s) or Hogma Fighter(s) or Hogma Scout(s)", new KillObjective(20, 41433, 41434, 41435, 41441, 47308, 47309));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_SUB_01_BOX", "BeforeStart", BeforeStart);
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

