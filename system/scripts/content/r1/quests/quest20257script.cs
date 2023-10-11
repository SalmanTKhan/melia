//--- Melia Script -----------------------------------------------------------
// In the Name of Faith (3)
//--- Description -----------------------------------------------------------
// Quest to Refine the magic in the Magic Crystals.
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

[QuestScript(20257)]
public class Quest20257Script : QuestScript
{
	protected override void Load()
	{
		SetId(20257);
		SetName("In the Name of Faith (3)");
		SetDescription("Refine the magic in the Magic Crystals");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN19_MQ13_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(59));
		AddPrerequisite(new CompletedPrerequisite("THORN19_MQ12"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("THORN19_MQ13_SPELLCRYSTAL", 1));
		AddReward(new ItemReward("Vis", 1062));

		AddDialogHook("THORN19_REFINE", "BeforeStart", BeforeStart);
		AddDialogHook("THORN19_REFINE", "BeforeEnd", BeforeEnd);
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN19_MQ14");
	}
}

