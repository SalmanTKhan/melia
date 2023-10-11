//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Oscaras.
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

[QuestScript(50205)]
public class Quest50205Script : QuestScript
{
	protected override void Load()
	{
		SetId(50205);
		SetName("Danger the Lurks in the Forest (4)");
		SetDescription("Talk with Oscaras");

		AddPrerequisite(new LevelPrerequisite(310));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ3"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14260));

		AddDialogHook("BRACKEN432_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN432_SUBQ_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_2_SQ4_START1", "BRACKEN43_2_SQ4", "Calm down and let's find the cure fast.", "Go to the Plague Doctor Master"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_2_SQ4_AGREE1");
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

		if (character.Inventory.HasItem("BRACKEN432_SUBQ4_ITEM1", 6) && character.Inventory.HasItem("BRACKEN432_SUBQ4_ITEM2", 6))
		{
			character.Inventory.RemoveItem("BRACKEN432_SUBQ4_ITEM1", 6);
			character.Inventory.RemoveItem("BRACKEN432_SUBQ4_ITEM2", 6);
			await dialog.Msg("BRACKEN43_2_SQ4_SUCC1");
			// Func/BRACKEN432_SUBQ4_COM_FUNC;
			await dialog.Msg("BRACKEN43_2_SQ4_SUCC2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

