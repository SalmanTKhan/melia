//--- Melia Script -----------------------------------------------------------
// Purification Ceremony (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90060)]
public class Quest90060Script : QuestScript
{
	protected override void Load()
	{
		SetId(90060);
		SetName("Purification Ceremony (1)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_5"));

		AddObjective("collect0", "Collect 10 Yellow Griba Pollen(s)", new CollectItemObjective("KATYN_45_3_SQ_7_ITEM", 10));
		AddDrop("KATYN_45_3_SQ_7_ITEM", 8f, "Mushroom_boy_yellow");

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_AJEL4", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_AJEL4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_6_ST", "KATYN_45_3_SQ_6", "I'll get it", "Please wait a bit"))
		{
			case 1:
				await dialog.Msg("KATYN_45_3_SQ_6_AG");
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

		if (character.Inventory.HasItem("KATYN_45_3_SQ_7_ITEM", 10))
		{
			character.Inventory.RemoveItem("KATYN_45_3_SQ_7_ITEM", 10);
			await dialog.Msg("KATYN_45_3_SQ_6_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

