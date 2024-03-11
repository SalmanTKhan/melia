//--- Melia Script -----------------------------------------------------------
// Prove by using his belongings
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Dorma.
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

[QuestScript(70544)]
public class Quest70544Script : QuestScript
{
	protected override void Load()
	{
		SetId(70544);
		SetName("Prove by using his belongings");
		SetDescription("Talk to Monk Dorma");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ04"));

		AddReward(new ItemReward("Vis", 4400));

		AddDialogHook("PILGRIM414_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_05_start", "PILGRIM41_4_SQ05", "Ask how you can do so", "Decline since you think it will be complicated"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_05_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_4_SQ05_ITEM", 1))
		{
			character.Inventory.RemoveItem("PILGRIM41_4_SQ05_ITEM", 1);
			await dialog.Msg("PILGRIM414_SQ_05_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

