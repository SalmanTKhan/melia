//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (5)
//--- Description -----------------------------------------------------------
// Quest to Talk with Oscaras.
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

[QuestScript(50206)]
public class Quest50206Script : QuestScript
{
	protected override void Load()
	{
		SetId(50206);
		SetName("Danger the Lurks in the Forest (5)");
		SetDescription("Talk with Oscaras");

		AddPrerequisite(new LevelPrerequisite(310));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ4"));

		AddObjective("collect0", "Collect 10 Bunkeyto Essence(s)", new CollectItemObjective("BRACKEN432_SUBQ5_ITEM1", 10));
		AddDrop("BRACKEN432_SUBQ5_ITEM1", 10f, "dorong");

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

		switch (await dialog.Select("BRACKEN43_2_SQ5_START1", "BRACKEN43_2_SQ5", "Bunkyto Essence, was it? It won't take long.", "Do it yourself."))
		{
			case 1:
				await dialog.Msg("BRACKEN43_2_SQ5_AGREE1");
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

		if (character.Inventory.HasItem("BRACKEN432_SUBQ5_ITEM1", 10))
		{
			character.Inventory.RemoveItem("BRACKEN432_SUBQ5_ITEM1", 10);
			await dialog.Msg("BRACKEN43_2_SQ5_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

