//--- Melia Script -----------------------------------------------------------
// Carlyle's Test (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Carlyle's Spirit.
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

[QuestScript(80014)]
public class Quest80014Script : QuestScript
{
	protected override void Load()
	{
		SetId(80014);
		SetName("Carlyle's Test (2)");
		SetDescription("Talk to Carlyle's Spirit");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CATACOMB_33_2_SQ_07_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_06"));
		AddPrerequisite(new ItemPrerequisite("CATACOMB_33_2_SQ_SYMBOL", -100));

		AddObjective("kill0", "Kill 1 Shadowgaler", new KillObjective(1, MonsterId.Boss_ShadowGaoler_Q3));

		AddReward(new ExpReward(274320, 274320));
		AddReward(new ItemReward("expCard5", 6));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeEnd", BeforeEnd);
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

