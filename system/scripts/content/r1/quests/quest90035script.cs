//--- Melia Script -----------------------------------------------------------
// Checking the Statues (2)
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

[QuestScript(90035)]
public class Quest90035Script : QuestScript
{
	protected override void Load()
	{
		SetId(90035);
		SetName("Checking the Statues (2)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_4"));

		AddObjective("collect0", "Collect 4 Sticky Liquid(s)", new CollectItemObjective("KATYN_45_1_SQ_5_ITEM1", 4));
		AddObjective("collect1", "Collect 4 Broken Bow(s)", new CollectItemObjective("KATYN_45_1_SQ_5_ITEM2", 4));
		AddDrop("KATYN_45_1_SQ_5_ITEM1", 8f, 57926, 57929);
		AddDrop("KATYN_45_1_SQ_5_ITEM2", 8f, "Stoulet_bow_blue");

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9065));

		AddDialogHook("KATYN_45_1_AJEL2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_AJEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_5_ST", "KATYN_45_1_SQ_5", "I can gather the materials you need.", "We should think of another solution."))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_5_AG");
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

		if (character.Inventory.HasItem("KATYN_45_1_SQ_5_ITEM1", 4) && character.Inventory.HasItem("KATYN_45_1_SQ_5_ITEM2", 4))
		{
			character.Inventory.RemoveItem("KATYN_45_1_SQ_5_ITEM1", 4);
			character.Inventory.RemoveItem("KATYN_45_1_SQ_5_ITEM2", 4);
			await dialog.Msg("KATYN_45_1_SQ_5_SU");
			// Func/SCR_KATYN_45_2_LOOK;
			await dialog.Msg("NPCAin/KATYN_45_1_AJEL2/ABSORB/0");
			await Task.Delay(1000);
			ZoneServer.Instance.World.FindNPC("KATYN_45_1_OWL1")?.PlayEffectLocal(character.Connection, "I_smoke013_dark1", 2f, "MID");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

