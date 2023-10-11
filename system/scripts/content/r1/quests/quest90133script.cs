//--- Melia Script -----------------------------------------------------------
// Find the Trace (5)
//--- Description -----------------------------------------------------------
// Quest to Investigate the trace.
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

[QuestScript(90133)]
public class Quest90133Script : QuestScript
{
	protected override void Load()
	{
		SetId(90133);
		SetName("Find the Trace (5)");
		SetDescription("Investigate the trace");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_DCAPITAL_20_5_SQ_90_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_90"));

		AddObjective("collect0", "Collect 1 Lieutenant's Demon Orders", new CollectItemObjective("F_DCAPITAL_20_5_SQ_90_ITEM", 1));
		AddDrop("F_DCAPITAL_20_5_SQ_90_ITEM", 10f, "boss_deadbone_Q2");

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_SQ_90_CLUE", "BeforeStart", BeforeStart);
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

		if (character.Inventory.HasItem("F_DCAPITAL_20_5_SQ_90_ITEM", 1) && character.Inventory.HasItem("F_DCAPITAL_20_5_SQ_ITEM3", 1))
		{
			character.Inventory.RemoveItem("F_DCAPITAL_20_5_SQ_90_ITEM", 1);
			character.Inventory.RemoveItem("F_DCAPITAL_20_5_SQ_ITEM3", 1);
			await dialog.Msg("F_DCAPITAL_20_5_SQ_50_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

