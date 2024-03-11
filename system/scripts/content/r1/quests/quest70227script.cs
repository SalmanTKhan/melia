//--- Melia Script -----------------------------------------------------------
// Honoring Allies
//--- Description -----------------------------------------------------------
// Quest to Talk with Mortimer.
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

[QuestScript(70227)]
public class Quest70227Script : QuestScript
{
	protected override void Load()
	{
		SetId(70227);
		SetName("Honoring Allies");
		SetDescription("Talk with Mortimer");

		AddPrerequisite(new LevelPrerequisite(215));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_08_1", "TABLELAND28_2_SQ08", "OK, I'll give you some", "Decline"))
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

		if (character.Inventory.HasItem("misc_Siaulav_blue", 1))
		{
			character.Inventory.RemoveItem("misc_Siaulav_blue", 1);
			await dialog.Msg("TABLELAND28_2_SQ_08_2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

