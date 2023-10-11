//--- Melia Script -----------------------------------------------------------
// For the Lack of Better Nourishment
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Reina.
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

[QuestScript(80214)]
public class Quest80214Script : QuestScript
{
	protected override void Load()
	{
		SetId(80214);
		SetName("For the Lack of Better Nourishment");
		SetDescription("Talk to Hunter Reina");

		AddPrerequisite(new LevelPrerequisite(173));
		AddPrerequisite(new CompletedPrerequisite("THORN39_2_SQ05"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_MQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_SQ_06_select01", "THORN39_2_SQ06", "I can find some meat for you.", "That will be hard"))
		{
			case 1:
				await dialog.Msg("THORN39_2_SQ_06_agree01");
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

		if (character.Inventory.HasItem("THORN39_2_SQ06_ITEM", 3))
		{
			character.Inventory.RemoveItem("THORN39_2_SQ06_ITEM", 3);
			await dialog.Msg("THORN39_2_SQ_06_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

