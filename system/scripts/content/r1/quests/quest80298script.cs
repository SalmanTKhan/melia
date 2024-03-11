//--- Melia Script -----------------------------------------------------------
// Hunger Brings Anxiety
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Oort.
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

[QuestScript(80298)]
public class Quest80298Script : QuestScript
{
	protected override void Load()
	{
		SetId(80298);
		SetName("Hunger Brings Anxiety");
		SetDescription("Talk to Hunter Oort");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_01"));

		AddObjective("collect0", "Collect 10 Humming Duke Meat(s)", new CollectItemObjective("F_3CMLAKE87_SQ1_ITEM", 10));
		AddDrop("F_3CMLAKE87_SQ1_ITEM", 8f, "Humming_duke");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19240));

		AddDialogHook("F_3CMLAKE_87_MQ_07_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_07_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_SQ_01_ST", "F_3CMLAKE_87_SQ_01", "I'll go find it.", "Get it yourself."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_SQ_01_AFST");
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

		if (character.Inventory.HasItem("F_3CMLAKE87_SQ1_ITEM", 10))
		{
			character.Inventory.RemoveItem("F_3CMLAKE87_SQ1_ITEM", 10);
			await dialog.Msg("F_3CMLAKE_87_SQ_01_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

