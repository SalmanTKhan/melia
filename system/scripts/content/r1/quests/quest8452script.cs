//--- Melia Script -----------------------------------------------------------
// Old Story (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(8452)]
public class Quest8452Script : QuestScript
{
	protected override void Load()
	{
		SetId(8452);
		SetName("Old Story (1)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new LevelPrerequisite(107));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_DRUNK_01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_MQ_01_01", "REMAINS40_MQ_01", "Help find his brother", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS40_MQ_01_AG");
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

		if (character.Inventory.HasItem("REMAINS40_MQ_01_ITEM", 1))
		{
			character.Inventory.RemoveItem("REMAINS40_MQ_01_ITEM", 1);
			await dialog.Msg("REMAINS40_MQ_01_03");
			dialog.HideNPC("REMAINS_40_MQ_01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

