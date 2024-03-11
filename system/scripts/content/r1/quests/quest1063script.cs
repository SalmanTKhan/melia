//--- Melia Script -----------------------------------------------------------
// The Eternal Adventure (4) - Deleted
//--- Description -----------------------------------------------------------
// Quest to Extinguished the research diary on the fire place.
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

[QuestScript(1063)]
public class Quest1063Script : QuestScript
{
	protected override void Load()
	{
		SetId(1063);
		SetName("The Eternal Adventure (4) - Deleted");
		SetDescription("Extinguished the research diary on the fire place");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS29_VACYS6_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new ItemPrerequisite("VACYS_note", -100), new ItemPrerequisite("ROKAS29_VACYS_ITEM_1", -100), new ItemPrerequisite("ROKAS29_VACYS_ITEM_2", -100), new ItemPrerequisite("ROKAS29_VACYS_ITEM_3", -100));

		AddDialogHook("ROKAS29_FIRE", "BeforeStart", BeforeStart);
		AddDialogHook("VACYS_SOUL", "BeforeEnd", BeforeEnd);
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

		dialog.HideNPC("VACYS_SOUL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

