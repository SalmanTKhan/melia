//--- Melia Script -----------------------------------------------------------
// Research Reports of the Priests
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Aden.
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

[QuestScript(20308)]
public class Quest20308Script : QuestScript
{
	protected override void Load()
	{
		SetId(20308);
		SetName("Research Reports of the Priests");
		SetDescription("Talk with Priest Aden");

		AddPrerequisite(new LevelPrerequisite(137));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_SQ03", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_SQ03_select", "CHATHEDRAL53_SQ03", "I will retrieve the research reports", "I'm busy"))
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

		if (character.Inventory.HasItem("PRIST_REPORT01", 1) && character.Inventory.HasItem("PRIST_REPORT02", 1) && character.Inventory.HasItem("PRIST_REPORT03", 1))
		{
			character.Inventory.RemoveItem("PRIST_REPORT01", 1);
			character.Inventory.RemoveItem("PRIST_REPORT02", 1);
			character.Inventory.RemoveItem("PRIST_REPORT03", 1);
			await dialog.Msg("CHATHEDRAL53_SQ03_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

