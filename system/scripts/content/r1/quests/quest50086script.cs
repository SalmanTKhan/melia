//--- Melia Script -----------------------------------------------------------
// Traitor's Diary
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(50086)]
public class Quest50086Script : QuestScript
{
	protected override void Load()
	{
		SetId(50086);
		SetName("Traitor's Diary");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new LevelPrerequisite(214));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_MQ060"));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7490));

		AddDialogHook("AMANDA_69_2", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_69_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_69_SQ020_startnp01", "UNDERFORTRESS_69_SQ020", "I will get it to you if I find them", "I will find it later"))
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

		if (character.Inventory.HasItem("UNDER69_SQ2_ITEM01", 1) && character.Inventory.HasItem("UNDER69_SQ2_ITEM02", 1) && character.Inventory.HasItem("UNDER69_SQ2_ITEM03", 1) && character.Inventory.HasItem("UNDER69_SQ2_ITEM04", 1))
		{
			character.Inventory.RemoveItem("UNDER69_SQ2_ITEM01", 1);
			character.Inventory.RemoveItem("UNDER69_SQ2_ITEM02", 1);
			character.Inventory.RemoveItem("UNDER69_SQ2_ITEM03", 1);
			character.Inventory.RemoveItem("UNDER69_SQ2_ITEM04", 1);
			await dialog.Msg("UNDER_69_SQ020_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

