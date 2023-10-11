//--- Melia Script -----------------------------------------------------------
// The Downward Spiral (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Zsaia.
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

[QuestScript(60295)]
public class Quest60295Script : QuestScript
{
	protected override void Load()
	{
		SetId(60295);
		SetName("The Downward Spiral (6)");
		SetDescription("Talk to Kupole Zsaia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL106_SQ_6_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_5"));

		AddObjective("kill0", "Kill 6 Bishop Hart(s) or Bishop Point(s)", new KillObjective(6, 59100, 59096));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 26000));

		AddDialogHook("DCAPITAL106_ZUSAIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL106_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL106_SQ_6_1", "DCAPITAL106_SQ_6", "You're wrong.", "I won't interfere."))
		{
			case 1:
				await dialog.Msg("DCAPITAL106_SQ_6_2");
				dialog.HideNPC("DCAPITAL106_ZUSAIA_NPC_1");
				// Func/DCAPITAL106_SUBQ6_COMP01;
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

		await dialog.Msg("DCAPITAL106_SQ_6_3");
		// Func/SCR_DCAPITAL106_SUBQ6_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

