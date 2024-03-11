//--- Melia Script -----------------------------------------------------------
// Injured Back
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90036)]
public class Quest90036Script : QuestScript
{
	protected override void Load()
	{
		SetId(90036);
		SetName("Injured Back");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_5"));

		AddDialogHook("KATYN_45_1_AJEL2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_AJEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_6_ST", "KATYN_45_1_SQ_6", "I can get the herbs for you.", "You should go somewhere safe and rest instead."))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_6_AG");
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

		if (character.Inventory.HasItem("KATYN_45_1_SQ_6_ITEM", 5))
		{
			character.Inventory.RemoveItem("KATYN_45_1_SQ_6_ITEM", 5);
			await dialog.Msg("KATYN_45_1_SQ_6_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

