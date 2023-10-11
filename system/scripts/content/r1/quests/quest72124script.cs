//--- Melia Script -----------------------------------------------------------
// Spiritually Infused Lakeland Sap
//--- Description -----------------------------------------------------------
// Quest to Talk to Leonardas.
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

[QuestScript(72124)]
public class Quest72124Script : QuestScript
{
	protected override void Load()
	{
		SetId(72124);
		SetName("Spiritually Infused Lakeland Sap");
		SetDescription("Talk to Leonardas");

		AddPrerequisite(new LevelPrerequisite(336));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ09"));

		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE262_SQ10_DLG01", "F_3CMLAKE262_SQ10", "I'll make it for you.", "That's too much of a hassle."))
		{
			case 1:
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

		if (character.Inventory.HasItem("3CMLAKE262_SQ10_ITEM02", 3))
		{
			character.Inventory.RemoveItem("3CMLAKE262_SQ10_ITEM02", 3);
			await dialog.Msg("3CMLAKE262_SQ10_DLG03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

