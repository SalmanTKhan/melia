//--- Melia Script -----------------------------------------------------------
// The Missing Orders
//--- Description -----------------------------------------------------------
// Quest to Talk with the Dragoon Master.
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

[QuestScript(72162)]
public class Quest72162Script : QuestScript
{
	protected override void Load()
	{
		SetId(72162);
		SetName("The Missing Orders");
		SetDescription("Talk with the Dragoon Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddReward(new ItemReward("Point_Stone_100_Q", 2));

		AddDialogHook("DRAGOON_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("DRAGOON_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DRAGOON_8_1_ST", "MASTER_DRAGOON1", "I will do it.", "That seems like it's outside my expertise."))
		{
			case 1:
				await dialog.Msg("JOB_DRAGOON_8_1_AG");
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

		if (character.Inventory.HasItem("JOB_DRAGOON_8_1_ITEM2", 1))
		{
			character.Inventory.RemoveItem("JOB_DRAGOON_8_1_ITEM2", 1);
			await dialog.Msg("MASTER_DRAGOON1_DLG1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

