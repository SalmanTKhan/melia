//--- Melia Script -----------------------------------------------------------
// Disease Detector [Plague Doctor Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Plague Doctor Master.
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

[QuestScript(30120)]
public class Quest30120Script : QuestScript
{
	protected override void Load()
	{
		SetId(30120);
		SetName("Disease Detector [Plague Doctor Advancement]");
		SetDescription("Talk with the Plague Doctor Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("PLAGUEDOCTOR_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("PLAGUEDOCTOR_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PLAGUEDOCTOR_7_1_select", "JOB_PLAGUEDOCTOR_7_1", "I want to learn for sure", "I'll wait a little bit"))
		{
			case 1:
				await dialog.Msg("JOB_PLAGUEDOCTOR_7_1_agree");
				dialog.UnHideNPC("JOB_PLAGUEDOCTOR71_NPC1");
				dialog.UnHideNPC("JOB_PLAGUEDOCTOR71_NPC2");
				dialog.UnHideNPC("JOB_PLAGUEDOCTOR71_NPC3");
				dialog.UnHideNPC("JOB_PLAGUEDOCTOR71_NPC4");
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

		if (character.Inventory.HasItem("JOB_PLAGUEDOCTOR71_ITEM1", 1) && character.Inventory.HasItem("JOB_PLAGUEDOCTOR71_ITEM2", 1) && character.Inventory.HasItem("JOB_PLAGUEDOCTOR71_ITEM3", 1) && character.Inventory.HasItem("JOB_PLAGUEDOCTOR71_ITEM4", 1))
		{
			character.Inventory.RemoveItem("JOB_PLAGUEDOCTOR71_ITEM1", 1);
			character.Inventory.RemoveItem("JOB_PLAGUEDOCTOR71_ITEM2", 1);
			character.Inventory.RemoveItem("JOB_PLAGUEDOCTOR71_ITEM3", 1);
			character.Inventory.RemoveItem("JOB_PLAGUEDOCTOR71_ITEM4", 1);
			await dialog.Msg("JOB_PLAGUEDOCTOR_7_1_succ");
			dialog.HideNPC("JOB_PLAGUEDOCTOR71_NPC1");
			dialog.HideNPC("JOB_PLAGUEDOCTOR71_NPC2");
			dialog.HideNPC("JOB_PLAGUEDOCTOR71_NPC3");
			dialog.HideNPC("JOB_PLAGUEDOCTOR71_NPC4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

