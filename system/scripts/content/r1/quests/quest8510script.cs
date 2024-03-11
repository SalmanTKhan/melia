//--- Melia Script -----------------------------------------------------------
// Church Gate (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Vaidutis.
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

[QuestScript(8510)]
public class Quest8510Script : QuestScript
{
	protected override void Load()
	{
		SetId(8510);
		SetName("Church Gate (1)");
		SetDescription("Talk to Follower Vaidutis");

		AddPrerequisite(new LevelPrerequisite(44));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE575_MQ_09"));

		AddObjective("collect0", "Collect 8 Power Crystal(s)", new CollectItemObjective("CHAPLE576_MQ_02_ITEM", 8));
		AddDrop("CHAPLE576_MQ_02_ITEM", 10f, "Corylus");

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("Vis", 660));

		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE576_MQ_01_01", "CHAPLE576_MQ_01", "Yeah, I'll collect them", "I'll wait a little bit"))
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

		if (character.Inventory.HasItem("CHAPLE576_MQ_02_ITEM", 8))
		{
			character.Inventory.RemoveItem("CHAPLE576_MQ_02_ITEM", 8);
			await dialog.Msg("CHAPLE576_MQ_01_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

