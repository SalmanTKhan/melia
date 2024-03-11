//--- Melia Script -----------------------------------------------------------
// Find the Trace (2)
//--- Description -----------------------------------------------------------
// Quest to Retrieve the Trace of Ausrine.
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

[QuestScript(90135)]
public class Quest90135Script : QuestScript
{
	protected override void Load()
	{
		SetId(90135);
		SetName("Find the Trace (2)");
		SetDescription("Retrieve the Trace of Ausrine");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_DCAPITAL_20_5_SQ_70_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_60"));

		AddObjective("kill0", "Kill 8 Red Velwriggler Mage(s) or Straw Walker(s)", new KillObjective(8, 57674, 58560));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_SQ_60_CLUE", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("F_DCAPITAL_20_5_SQ_ITEM1", 1))
		{
			character.Inventory.RemoveItem("F_DCAPITAL_20_5_SQ_ITEM1", 1);
			await dialog.Msg("F_DCAPITAL_20_5_SQ_70_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

