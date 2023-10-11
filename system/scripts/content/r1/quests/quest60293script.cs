//--- Melia Script -----------------------------------------------------------
// The Downward Spiral (4)
//--- Description -----------------------------------------------------------
// Quest to Chase Kupole Zsaia.
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

[QuestScript(60293)]
public class Quest60293Script : QuestScript
{
	protected override void Load()
	{
		SetId(60293);
		SetName("The Downward Spiral (4)");
		SetDescription("Chase Kupole Zsaia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL106_SQ_4_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_3"));

		AddObjective("kill0", "Kill 7 Bishop Point(s) or Bishop Hart(s)", new KillObjective(7, 59096, 59100));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 26000));

		AddDialogHook("DCAPITAL106_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/SCR_DCAPITAL106_SUBQ4_COMP;
		await dialog.Msg("DCAPITAL106_SQ_4_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

