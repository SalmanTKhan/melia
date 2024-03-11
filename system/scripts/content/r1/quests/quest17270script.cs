//--- Melia Script -----------------------------------------------------------
// Tie Tightly
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Basil.
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

[QuestScript(17270)]
public class Quest17270Script : QuestScript
{
	protected override void Load()
	{
		SetId(17270);
		SetName("Tie Tightly");
		SetDescription("Talk to Watcher Basil");

		AddPrerequisite(new LevelPrerequisite(29));

		AddObjective("collect0", "Collect 7 Ritualistic Rope(s)", new CollectItemObjective("GELE572_MQ_03_ITEM", 7));
		AddDrop("GELE572_MQ_03_ITEM", 10f, "Npanto_staff");

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("GELE572_NPC_BASIL", "BeforeStart", BeforeStart);
		AddDialogHook("GELE572_NPC_BASIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE572_MQ_08_ST", "GELE572_MQ_08", "I will try", "About the Cursed Doll", "Decline"))
		{
			case 1:
				await dialog.Msg("GELE572_MQ_08_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE572_MQ_08_ST_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("GELE572_MQ_03_ITEM", 7))
		{
			character.Inventory.RemoveItem("GELE572_MQ_03_ITEM", 7);
			await dialog.Msg("GELE572_MQ_08_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

