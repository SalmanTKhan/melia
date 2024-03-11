//--- Melia Script -----------------------------------------------------------
// Good Use For a Wand (1)
//--- Description -----------------------------------------------------------
// Quest to Check the Suspicious Wand Fragment.
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

[QuestScript(80201)]
public class Quest80201Script : QuestScript
{
	protected override void Load()
	{
		SetId(80201);
		SetName("Good Use For a Wand (1)");
		SetDescription("Check the Suspicious Wand Fragment");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CHATHEDRAL53_SQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(137));

		AddObjective("kill0", "Kill 12 Darkness Anchor(s)", new KillObjective(12, MonsterId.Anchor_Mage));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_SQ07_OBJ1", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ03", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("CHATHEDRAL53_SQ07_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

