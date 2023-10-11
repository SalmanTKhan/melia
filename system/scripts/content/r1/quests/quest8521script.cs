//--- Melia Script -----------------------------------------------------------
// Mark Territory
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Tomas.
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

[QuestScript(8521)]
public class Quest8521Script : QuestScript
{
	protected override void Load()
	{
		SetId(8521);
		SetName("Mark Territory");
		SetDescription("Talk to Follower Tomas");

		AddPrerequisite(new LevelPrerequisite(40));

		AddObjective("collect0", "Collect 6 Eye of Madness(s)", new CollectItemObjective("CHAPLE575_MQ_03_ITEM", 6));
		AddDrop("CHAPLE575_MQ_03_ITEM", 8f, "zombiegirl2_chpel");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 600));

		AddDialogHook("CHAPEL_TOMAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_TOMAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE575_MQ_03_01", "CHAPLE575_MQ_03", "Alright, I'll help you", "I'll wait a little bit"))
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

		if (character.Inventory.HasItem("CHAPLE575_MQ_03_ITEM", 6))
		{
			character.Inventory.RemoveItem("CHAPLE575_MQ_03_ITEM", 6);
			await dialog.Msg("CHAPLE575_MQ_03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

