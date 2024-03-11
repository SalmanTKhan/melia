//--- Melia Script -----------------------------------------------------------
// Commander Vacenin (1)
//--- Description -----------------------------------------------------------
// Quest to Find the Messenger.
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

[QuestScript(4701)]
public class Quest4701Script : QuestScript
{
	protected override void Load()
	{
		SetId(4701);
		SetName("Commander Vacenin (1)");
		SetDescription("Find the Messenger");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN7_PREBOSS_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(106));

		AddObjective("kill0", "Kill 5 Bushspider(s) or Ellom(s)", new KillObjective(5, 400141, 41436));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("katyn_7_Messenger", 1));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("KATYN7_KEYNPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN7_KEYNPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("f_katyn_7_ev001_agree1", "KATYN_KEY_01", "I can help you", "About Kateen Forest", "I'm busy"))
		{
			case 1:
				await dialog.Msg("f_katyn_7_ev001_AG");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("f_katyn_7_ev001_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("f_katyn_7_ev001_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

