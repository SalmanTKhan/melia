//--- Melia Script -----------------------------------------------------------
// Eyes Off for a Moment
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Yosana.
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

[QuestScript(20315)]
public class Quest20315Script : QuestScript
{
	protected override void Load()
	{
		SetId(20315);
		SetName("Eyes Off for a Moment");
		SetDescription("Talk to Priest Yosana");

		AddPrerequisite(new LevelPrerequisite(140));

		AddObjective("collect0", "Collect 6 Priest Yosana's Research Data(s)", new CollectItemObjective("CATHEDRAL54_SQ02_ITEM", 6));
		AddDrop("CATHEDRAL54_SQ02_ITEM", 6f, "Stoulet_blue");

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("PRIST_REPORT01", 1));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3640));

		AddDialogHook("CHATHEDRAL54_SQ03_PART1", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_SQ03_PART1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_SQ02_PART1_select01", "CHATHEDRAL54_SQ02_PART1", "Alright, I'll help you", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("CATHEDRAL54_SQ02_ITEM", 6))
		{
			character.Inventory.RemoveItem("CATHEDRAL54_SQ02_ITEM", 6);
			await dialog.Msg("CHATHEDRAL54_SQ02_PART1_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

