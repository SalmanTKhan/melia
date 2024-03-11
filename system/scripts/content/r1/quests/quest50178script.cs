//--- Melia Script -----------------------------------------------------------
// Cursed Statues (3)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Cursed Statues with the Purification Sphere.
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

[QuestScript(50178)]
public class Quest50178Script : QuestScript
{
	protected override void Load()
	{
		SetId(50178);
		SetName("Cursed Statues (3)");
		SetDescription("Destroy the Cursed Statues with the Purification Sphere");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_73_SQ3_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(250));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ9"));

		AddReward(new ExpReward(8865549, 8865549));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10000));

		AddDialogHook("TABLE73_SUB_ARTIFACT2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUB_ARTIFACT2", "BeforeEnd", BeforeEnd);
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

