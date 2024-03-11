//--- Melia Script -----------------------------------------------------------
// And, Eternal Repose (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the integrator.
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

[QuestScript(40930)]
public class Quest40930Script : QuestScript
{
	protected override void Load()
	{
		SetId(40930);
		SetName("And, Eternal Repose (2)");
		SetDescription("Destroy the integrator");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH_58_SQ_080_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_070"));
		AddPrerequisite(new ItemPrerequisite("FLASH_58_SQ_070_ITEM_3", -100));

		AddObjective("kill0", "Kill 26 Red Infro Holder(s) or Blue Socket(s) or Green Infro Holder Shaman(s)", new KillObjective(26, 57884, 57925, 57887));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("FLASH_SOUL_COLLECTOR", "BeforeStart", BeforeStart);
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

