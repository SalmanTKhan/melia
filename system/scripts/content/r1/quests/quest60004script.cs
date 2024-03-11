//--- Melia Script -----------------------------------------------------------
// The Teeth of Revenge (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Audra.
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

[QuestScript(60004)]
public class Quest60004Script : QuestScript
{
	protected override void Load()
	{
		SetId(60004);
		SetName("The Teeth of Revenge (2)");
		SetDescription("Talk to Kupole Audra");

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_02"));

		AddObjective("collect0", "Collect 7 Blut's Mark(s)", new CollectItemObjective("VPRISON511_MQ_03_ITEM", 7));
		AddDrop("VPRISON511_MQ_03_ITEM", 7f, 57316, 57315, 57313, 57319);

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 8));
		AddReward(new ItemReward("Vis", 4379));

		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON511_MQ_AUDRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_MQ_03_01", "VPRISON511_MQ_03", "Alright, I'll help you", "About Demon Lord Blut", "I need more preparation"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("VPRISON511_MQ_03_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("VPRISON511_MQ_03_ITEM", 7))
		{
			character.Inventory.RemoveItem("VPRISON511_MQ_03_ITEM", 7);
			await dialog.Msg("VPRISON511_MQ_03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

