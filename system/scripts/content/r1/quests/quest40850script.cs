//--- Melia Script -----------------------------------------------------------
// What is in the box...?
//--- Description -----------------------------------------------------------
// Quest to Open the treasure chest.
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

[QuestScript(40850)]
public class Quest40850Script : QuestScript
{
	protected override void Load()
	{
		SetId(40850);
		SetName("What is in the box...?");
		SetDescription("Open the treasure chest");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH_29_1_SQ_080_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(204));

		AddObjective("kill0", "Kill 20 Orange Minos(s) or Red Infro Holder Archer(s) or Green Minos Mage(s)", new KillObjective(20, 57920, 57886, 57922));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH_29_1_BOX", "BeforeStart", BeforeStart);
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

