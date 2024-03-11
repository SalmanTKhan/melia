//--- Melia Script -----------------------------------------------------------
// Sound of the Wood [Fletcher Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Fletcher Master.
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

[QuestScript(8718)]
public class Quest8718Script : QuestScript
{
	protected override void Load()
	{
		SetId(8718);
		SetName("Sound of the Wood [Fletcher Advancement]");
		SetDescription("Meet the Fletcher Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FLETCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FLETCHER4_1_01", "JOB_FLETCHER4_1", "How can I get that?", "I'd like to stop"))
		{
			case 1:
				await dialog.Msg("JOB_FLETCHER4_1_02");
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

		if (character.Inventory.HasItem("JOB_FLETCHER4_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_FLETCHER4_ITEM", 10);
			await dialog.Msg("JOB_FLETCHER4_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

