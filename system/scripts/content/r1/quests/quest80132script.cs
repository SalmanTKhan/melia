//--- Melia Script -----------------------------------------------------------
// Kupole Rescue Mission (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80132)]
public class Quest80132Script : QuestScript
{
	protected override void Load()
	{
		SetId(80132);
		SetName("Kupole Rescue Mission (3)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_6"));

		AddObjective("collect0", "Collect 4 Demon Magic Stone(s)", new CollectItemObjective("LIMESTONE_52_2_MQ_7_STONE", 4));
		AddDrop("LIMESTONE_52_2_MQ_7_STONE", 10f, "flamme_priest_green");

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONECAVE_52_2_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_2_EVIL_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_7_start", "LIMESTONE_52_2_MQ_7", "Let's go, we can do this.", "That's going to be difficult, sorry."))
		{
			case 1:
				// Func/LIMESTONE_52_2_REENTER_RUN;
				await dialog.Msg("LIMESTONE_52_2_MQ_7_agree");
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

		if (character.Inventory.HasItem("LIMESTONE_52_2_MQ_7_STONE", 4))
		{
			character.Inventory.RemoveItem("LIMESTONE_52_2_MQ_7_STONE", 4);
			// Func/LIMESTONE_52_2_MQ_7_END;
			dialog.HideNPC("LIMESTONE_52_2_DARKWALL_2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

