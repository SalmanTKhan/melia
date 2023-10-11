//--- Melia Script -----------------------------------------------------------
// The Downward Spiral (7)
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

[QuestScript(60296)]
public class Quest60296Script : QuestScript
{
	protected override void Load()
	{
		SetId(60296);
		SetName("The Downward Spiral (7)");
		SetDescription("Talk to Kupole Grisia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL106_SQ_7_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_6"));

		AddObjective("kill0", "Kill 6 Bishop Point(s) or Bishop Hart(s)", new KillObjective(6, 59096, 59100));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 26000));

		AddDialogHook("DCAPITAL106_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL106_GRISIA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL106_SQ_7_1", "DCAPITAL106_SQ_7", "I'll go and have a look.", "I won't go"))
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

		await dialog.Msg("DCAPITAL106_SQ_7_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

