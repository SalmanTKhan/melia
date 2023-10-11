//--- Melia Script -----------------------------------------------------------
// Make Drinking Water
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Oort.
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

[QuestScript(80299)]
public class Quest80299Script : QuestScript
{
	protected override void Load()
	{
		SetId(80299);
		SetName("Make Drinking Water");
		SetDescription("Talk to Hunter Oort");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_01"));

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

		switch (await dialog.Select("F_3CMLAKE_87_SQ_02_ST", "F_3CMLAKE_87_SQ_02", "I'll be right back.", "Sounds like too much trouble."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_SQ_02_AFST");
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

		if (character.Inventory.HasItem("F_3CMLAKE87_SQ2_ITEM", 8))
		{
			character.Inventory.RemoveItem("F_3CMLAKE87_SQ2_ITEM", 8);
			await dialog.Msg("F_3CMLAKE_87_SQ_02_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

