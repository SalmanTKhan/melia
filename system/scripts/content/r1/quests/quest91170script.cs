//--- Melia Script -----------------------------------------------------------
// They have suffered enough
//--- Description -----------------------------------------------------------
// Quest to Make a conversation with Edmundas.
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

[QuestScript(91170)]
public class Quest91170Script : QuestScript
{
	protected override void Load()
	{
		SetId(91170);
		SetName("They have suffered enough");
		SetDescription("Make a conversation with Edmundas");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_5"));

		AddObjective("collect0", "Collect 10 Pokubu Meat(s)", new CollectItemObjective("EP15_1_FABBEY1_MQ_6_ITEM1", 10));
		AddDrop("EP15_1_FABBEY1_MQ_6_ITEM1", 6f, "ep15_1_Pokubu_ferocious");

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_AD2", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY1_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY1_6_DLG1", "EP15_1_F_ABBEY1_6", "I'll go get it.", "I have other obligations."))
		{
			case 1:
				await dialog.Msg("EP15_1_F_ABBEY1_6_DLG2");
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

		if (character.Inventory.HasItem("EP15_1_FABBEY1_MQ_6_ITEM1", 10))
		{
			character.Inventory.RemoveItem("EP15_1_FABBEY1_MQ_6_ITEM1", 10);
			await dialog.Msg("EP15_1_F_ABBEY1_6_DLG3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

