//--- Melia Script -----------------------------------------------------------
// Honor of the Old Sea [Corsair Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Corsair Master.
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

[QuestScript(30033)]
public class Quest30033Script : QuestScript
{
	protected override void Load()
	{
		SetId(30033);
		SetName("Honor of the Old Sea [Corsair Advancement]");
		SetDescription("Talk to the Corsair Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CORSAIR_6_1_select", "JOB_CORSAIR_6_1", "I'll try to find them", "Tell that it's absurd"))
		{
			case 1:
				await dialog.Msg("JOB_CORSAIR_6_1_agree");
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
			await dialog.Msg("JOB_CORSAIR_6_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

