//--- Melia Script -----------------------------------------------------------
// Gathering goods for the journey
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim George.
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

[QuestScript(70554)]
public class Quest70554Script : QuestScript
{
	protected override void Load()
	{
		SetId(70554);
		SetName("Gathering goods for the journey");
		SetDescription("Talk to Pilgrim George");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ13"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_15_start", "PILGRIM41_4_SQ15", "Say that Lepusbunnies are nothing to fear", "Say that you don't want to help since they are tough"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_15_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_4_SQ15_ITEM", 15))
		{
			character.Inventory.RemoveItem("PILGRIM41_4_SQ15_ITEM", 15);
			await dialog.Msg("PILGRIM414_SQ_15_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

