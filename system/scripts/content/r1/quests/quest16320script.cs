//--- Melia Script -----------------------------------------------------------
// Desirable Combs
//--- Description -----------------------------------------------------------
// Quest to Talk with Valda.
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

[QuestScript(16320)]
public class Quest16320Script : QuestScript
{
	protected override void Load()
	{
		SetId(16320);
		SetName("Desirable Combs");
		SetDescription("Talk with Valda");

		AddPrerequisite(new LevelPrerequisite(163));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("SIAULIAI_46_3_SQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_3_SQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_3_SQ_03_select", "SIAULIAI_46_3_SQ_03", "I'll get it", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_3_SQ_03_start_prog");
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

		if (character.Inventory.HasItem("SIAULIAI_46_3_SQ_03_ITEM", 6))
		{
			character.Inventory.RemoveItem("SIAULIAI_46_3_SQ_03_ITEM", 6);
			await dialog.Msg("SIAULIAI_46_3_SQ_03_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

