//--- Melia Script -----------------------------------------------------------
// Locate the Pahtogen [Plague Doctor Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Plague Doctor Master.
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

[QuestScript(50242)]
public class Quest50242Script : QuestScript
{
	protected override void Load()
	{
		SetId(50242);
		SetName("Locate the Pahtogen [Plague Doctor Advancement]");
		SetDescription("Talk to the Plague Doctor Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("PLAGUEDOCTOR_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("PLAGUEDOCTOR_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PLAGUEDOCTOR_8_1_START", "JOB_PLAGUEDOCTOR_8_1", "I will get the samples.", "I'll do it later"))
		{
			case 1:
				await dialog.Msg("JOB_PLAGUEDOCTOR_8_1_AGREE1");
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

		if (character.Inventory.HasItem("JOB_2_PLAGUEDOCTOR_ITEM1", 60) && character.Inventory.HasItem("JOB_2_PLAGUEDOCTOR_ITEM2", 60))
		{
			character.Inventory.RemoveItem("JOB_2_PLAGUEDOCTOR_ITEM1", 60);
			character.Inventory.RemoveItem("JOB_2_PLAGUEDOCTOR_ITEM2", 60);
			await dialog.Msg("JOB_PLAGUEDOCTOR_8_1_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

