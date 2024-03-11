//--- Melia Script -----------------------------------------------------------
// Beholder
//--- Description -----------------------------------------------------------
// Quest to Beholder's Careful Trick.
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

[QuestScript(20290)]
public class Quest20290Script : QuestScript
{
	protected override void Load()
	{
		SetId(20290);
		SetName("Beholder");
		SetDescription("Beholder's Careful Trick");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN19_MQ04_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ08"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN_BLACKMAN_TRIGGER1", "BeforeStart", BeforeStart);
		AddDialogHook("THORN_BLACKMAN_TRIGGER1", "BeforeEnd", BeforeEnd);
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

