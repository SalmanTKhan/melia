//--- Melia Script -----------------------------------------------------------
// The Downward Spiral (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60291)]
public class Quest60291Script : QuestScript
{
	protected override void Load()
	{
		SetId(60291);
		SetName("The Downward Spiral (2)");
		SetDescription("Talk to Kupole Grisia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL106_SQ_2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_1"));

		AddObjective("kill0", "Kill 8 Bishop Hart(s) or Bishop Point(s)", new KillObjective(8, 59100, 59096));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 26000));

		AddDialogHook("DCAPITAL106_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL106_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL106_SQ_2_1", "DCAPITAL106_SQ_2", "I'll head behind the Waterworks Office.", "I won't go"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("DCAPITAL106_SQ_2_3");
		// Func/SCR_DCAPITAL106_SUBQ2_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

