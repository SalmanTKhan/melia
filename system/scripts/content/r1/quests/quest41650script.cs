//--- Melia Script -----------------------------------------------------------
// Lost and Found (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Merrisa.
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

[QuestScript(41650)]
public class Quest41650Script : QuestScript
{
	protected override void Load()
	{
		SetId(41650);
		SetName("Lost and Found (2)");
		SetDescription("Talk to Merrisa");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM_48_SQ_050_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(110));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_48_SQ_040"));

		AddObjective("collect0", "Collect 4 Damp Piece of Paper(s)", new CollectItemObjective("PILGRIM_48_SQ_050_ITEM_1", 4));
		AddDrop("PILGRIM_48_SQ_050_ITEM_1", 10f, "Sec_InfroBurk");

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2640));

		AddDialogHook("PILGRIM_48_JURATE", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_JURATE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_48_SQ_050_ST", "PILGRIM_48_SQ_050", "I will check it", "I'll get going then"))
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

		if (character.Inventory.HasItem("PILGRIM_48_SQ_050_ITEM_1", 4))
		{
			character.Inventory.RemoveItem("PILGRIM_48_SQ_050_ITEM_1", 4);
			await dialog.Msg("PILGRIM_48_SQ_050_COMP");
			await Task.Delay(1500);
			await dialog.Msg("PILGRIM_48_SQ_050_COMP_2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

