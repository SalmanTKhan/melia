//--- Melia Script -----------------------------------------------------------
// Refugees of Mishekan Forest(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Curtis.
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

[QuestScript(50250)]
public class Quest50250Script : QuestScript
{
	protected override void Load()
	{
		SetId(50250);
		SetName("Refugees of Mishekan Forest(1)");
		SetDescription("Talk to Curtis");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES56_1_SQ2"));

		AddObjective("collect0", "Collect 12 Head Flower(s)", new CollectItemObjective("WHITETREES561_SUBQ3_ITEM", 12));
		AddDrop("WHITETREES561_SUBQ3_ITEM", 10f, "florabbi");

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15369));

		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES561_SUBQ3_START1", "WHITETREES56_1_SQ3", "What can I do for you?", "It's your problem, isn't it?"))
		{
			case 1:
				await dialog.Msg("WHITETREES561_SUBQ3_AGREE1");
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

		if (character.Inventory.HasItem("WHITETREES561_SUBQ3_ITEM", 12))
		{
			character.Inventory.RemoveItem("WHITETREES561_SUBQ3_ITEM", 12);
			await dialog.Msg("WHITETREES561_SUBQ3_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

