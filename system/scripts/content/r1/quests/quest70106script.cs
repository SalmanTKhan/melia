//--- Melia Script -----------------------------------------------------------
// The Precious Scripture
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Wiley.
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

[QuestScript(70106)]
public class Quest70106Script : QuestScript
{
	protected override void Load()
	{
		SetId(70106);
		SetName("The Precious Scripture");
		SetDescription("Talk to Monk Wiley");

		AddPrerequisite(new LevelPrerequisite(173));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_SQ_01_1", "THORN39_2_SQ01", "I will find the scripture for him", "I don't have time for that"))
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

		if (character.Inventory.HasItem("THORN39_2_SQ01_ITEM", 8))
		{
			character.Inventory.RemoveItem("THORN39_2_SQ01_ITEM", 8);
			await dialog.Msg("THORN39_2_SQ_01_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

