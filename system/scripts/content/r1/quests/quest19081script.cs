//--- Melia Script -----------------------------------------------------------
// Hidden and Hidden Again
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sadhu Master.
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

[QuestScript(19081)]
public class Quest19081Script : QuestScript
{
	protected override void Load()
	{
		SetId(19081);
		SetName("Hidden and Hidden Again");
		SetDescription("Talk to the Sadhu Master");

		AddPrerequisite(new LevelPrerequisite(115));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER_44_HQ_01"), new CompletedPrerequisite("FIRETOWER_45_HQ_01"));

		AddDialogHook("JOB_SADU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SADU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FEDIMIAN_HQ_02_ST", "FEDIMIAN_HQ_02", "I'll get it. ", "Decline"))
		{
			case 1:
				await dialog.Msg("FEDIMIAN_HQ_02_AC");
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

		if (character.Inventory.HasItem("misc_jore02", 1))
		{
			character.Inventory.RemoveItem("misc_jore02", 1);
			await dialog.Msg("FEDIMIAN_HQ_02_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

