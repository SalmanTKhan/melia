//--- Melia Script -----------------------------------------------------------
// Oppotunity and Preparation
//--- Description -----------------------------------------------------------
// Quest to Hidden Royal Mausoleum Book appeared.
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

[QuestScript(19021)]
public class Quest19021Script : QuestScript
{
	protected override void Load()
	{
		SetId(19021);
		SetName("Oppotunity and Preparation");
		SetDescription("Hidden Royal Mausoleum Book appeared");

		AddPrerequisite(new LevelPrerequisite(81));

		AddDialogHook("ZACHARIEL_35_HQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHARIEL_35_HQ_01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHARIEL_35_HQ_01_ST", "ZACHARIEL_35_HQ_01", "I'll find what you want", "Close book"))
		{
			case 1:
				await dialog.Msg("ZACHARIEL_35_HQ_01_AC");
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

		if (character.Inventory.HasItem("misc_jore10", 1))
		{
			character.Inventory.RemoveItem("misc_jore10", 1);
			await dialog.Msg("ZACHARIEL_35_HQ_01_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

