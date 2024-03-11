//--- Melia Script -----------------------------------------------------------
// Filtered Water
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Jones.
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

[QuestScript(70147)]
public class Quest70147Script : QuestScript
{
	protected override void Load()
	{
		SetId(70147);
		SetName("Filtered Water");
		SetDescription("Talk to Monk Jones");

		AddPrerequisite(new LevelPrerequisite(179));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_SQ_02_1", "THORN39_3_SQ02", "I will definitely help", "Decline"))
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

		if (character.Inventory.HasItem("THORN39_3_SQ02_ITEM", 12))
		{
			character.Inventory.RemoveItem("THORN39_3_SQ02_ITEM", 12);
			await dialog.Msg("THORN39_3_SQ_02_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

