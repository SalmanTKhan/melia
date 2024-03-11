//--- Melia Script -----------------------------------------------------------
// Honor of the Old Sea
//--- Description -----------------------------------------------------------
// Quest to Talk to the Corsair Master.
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

[QuestScript(72155)]
public class Quest72155Script : QuestScript
{
	protected override void Load()
	{
		SetId(72155);
		SetName("Honor of the Old Sea");
		SetDescription("Talk to the Corsair Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddReward(new ItemReward("Point_Stone_100_Q", 2));

		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CORSAIR_6_1_select", "MASTER_CORSAIR1", "I'll try to find them", "Tell that it's absurd"))
		{
			case 1:
				await dialog.Msg("MASTER_CORSAIR1_DLG1");
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

		if (character.Inventory.HasItem("JOB_CORSAIR_6_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_CORSAIR_6_1_ITEM", 1);
			await dialog.Msg("MASTER_CORSAIR1_DLG2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

