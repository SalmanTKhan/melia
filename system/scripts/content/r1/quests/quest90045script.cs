//--- Melia Script -----------------------------------------------------------
// Once Again, Purification (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90045)]
public class Quest90045Script : QuestScript
{
	protected override void Load()
	{
		SetId(90045);
		SetName("Once Again, Purification (1)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_3"));

		AddObjective("collect0", "Collect 8 Shrivelled Black Stem(s)", new CollectItemObjective("KATYN_45_2_SQ_4_ITEM", 8));
		AddDrop("KATYN_45_2_SQ_4_ITEM", 8f, "pappus_kepa_purple");

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_AJEL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_AJEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_4_ST", "KATYN_45_2_SQ_4", "I'll collect it", "That's going to be hard."))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_4_AG");
				dialog.HideNPC("KATYN_45_2_AJEL1");
				await dialog.Msg("FadeOutIN/2000");
				dialog.UnHideNPC("KATYN_45_2_AJEL2");
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

		if (character.Inventory.HasItem("KATYN_45_2_SQ_4_ITEM", 8))
		{
			character.Inventory.RemoveItem("KATYN_45_2_SQ_4_ITEM", 8);
			await dialog.Msg("KATYN_45_2_SQ_4_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

