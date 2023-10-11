//--- Melia Script -----------------------------------------------------------
// For Times Like These
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70610)]
public class Quest70610Script : QuestScript
{
	protected override void Load()
	{
		SetId(70610);
		SetName("For Times Like These");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(274));
		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ09"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11234));

		AddDialogHook("ABBEY416_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY416_SQ_10_start", "ABBEY41_6_SQ10", "Say that you will hurry and bring the needed goods", "Say that you think you should monitor the situation a while"))
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

		if (character.Inventory.HasItem("ABBEY41_6_SQ10_ITEM", 10))
		{
			character.Inventory.RemoveItem("ABBEY41_6_SQ10_ITEM", 10);
			await dialog.Msg("ABBEY416_SQ_10_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

