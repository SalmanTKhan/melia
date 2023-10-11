//--- Melia Script -----------------------------------------------------------
// They Hid Her (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80151)]
public class Quest80151Script : QuestScript
{
	protected override void Load()
	{
		SetId(80151);
		SetName("They Hid Her (1)");
		SetDescription("Talk to Kupole Serija");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_2"));

		AddObjective("collect0", "Collect 10 Green Zolem Core(s)", new CollectItemObjective("LIMESTONE_52_4_MQ_3_CHARM", 10));
		AddDrop("LIMESTONE_52_4_MQ_3_CHARM", 10f, "Zolem_green");

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12516));

		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_3_start", "LIMESTONE_52_4_MQ_3", "I can do it.", "I don't think so."))
		{
			case 1:
				// Func/LIMESTONE_52_4_REENTER_RUN;
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

		if (character.Inventory.HasItem("LIMESTONE_52_4_MQ_3_CHARM", 10))
		{
			character.Inventory.RemoveItem("LIMESTONE_52_4_MQ_3_CHARM", 10);
			await dialog.Msg("LIMESTONE_52_4_MQ_3_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

