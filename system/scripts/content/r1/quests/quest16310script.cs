//--- Melia Script -----------------------------------------------------------
// Help My Farm Recover
//--- Description -----------------------------------------------------------
// Quest to Talk to Riesz.
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

[QuestScript(16310)]
public class Quest16310Script : QuestScript
{
	protected override void Load()
	{
		SetId(16310);
		SetName("Help My Farm Recover");
		SetDescription("Talk to Riesz");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_3_SQ_02_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(163));

		AddObjective("collect0", "Collect 1 Bag of Farming Tools", new CollectItemObjective("SIAULIAI_46_3_SQ_02_ITEM", 1));
		AddDrop("SIAULIAI_46_3_SQ_02_ITEM", 10f, "boss_honeypin_Q1");

		AddReward(new ExpReward(1884006, 1884006));
		AddReward(new ItemReward("expCard9", 5));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("SIAULIAI_46_3_SQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_3_SQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_3_SQ_02_select", "SIAULIAI_46_3_SQ_02", "I will find the farm tools", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_3_SQ_02_start_prog");
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

		if (character.Inventory.HasItem("SIAULIAI_46_3_SQ_02_ITEM", 1))
		{
			character.Inventory.RemoveItem("SIAULIAI_46_3_SQ_02_ITEM", 1);
			await dialog.Msg("SIAULIAI_46_3_SQ_02_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

