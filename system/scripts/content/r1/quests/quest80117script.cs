//--- Melia Script -----------------------------------------------------------
// To the Goddess' Refuge (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Trija.
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

[QuestScript(80117)]
public class Quest80117Script : QuestScript
{
	protected override void Load()
	{
		SetId(80117);
		SetName("To the Goddess' Refuge (1)");
		SetDescription("Talk to Kupole Trija");

		AddPrerequisite(new LevelPrerequisite(287));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_MQ_4"));

		AddObjective("collect0", "Collect 5 Evil Demon Essence(s)", new CollectItemObjective("LIMESTONE_52_1_MQ_5_EVILCORE", 5));
		AddDrop("LIMESTONE_52_1_MQ_5_EVILCORE", 10f, "Flak_green");

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12054));

		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_1_MQ_5_start", "LIMESTONE_52_1_MQ_5", "I'll try to find them", "I'm not sure"))
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

		if (character.Inventory.HasItem("LIMESTONE_52_1_MQ_5_EVILCORE", 5))
		{
			character.Inventory.RemoveItem("LIMESTONE_52_1_MQ_5_EVILCORE", 5);
			await dialog.Msg("LIMESTONE_52_1_MQ_5_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

