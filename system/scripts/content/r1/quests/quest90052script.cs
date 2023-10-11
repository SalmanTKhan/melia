//--- Melia Script -----------------------------------------------------------
// Precious Carving Knife
//--- Description -----------------------------------------------------------
// Quest to Talk to Trainee Leryd.
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

[QuestScript(90052)]
public class Quest90052Script : QuestScript
{
	protected override void Load()
	{
		SetId(90052);
		SetName("Precious Carving Knife");
		SetDescription("Talk to Trainee Leryd");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new ItemPrerequisite("KATYN_45_2_SQ_11_ITEM", -100));

		AddObjective("collect0", "Collect 1 Old Carving Knife", new CollectItemObjective("KATYN_45_2_SQ_11_ITEM2", 1));
		AddDrop("KATYN_45_2_SQ_11_ITEM2", 0.5f, 400542, 400483, 400304);

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_SCULPTOR1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_SCULPTOR1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_11_ST", "KATYN_45_2_SQ_11", "I'll bring it to you if I find it.", "I'm sure you'll find it eventually."))
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

		if (character.Inventory.HasItem("KATYN_45_2_SQ_11_ITEM2", 1))
		{
			character.Inventory.RemoveItem("KATYN_45_2_SQ_11_ITEM2", 1);
			await dialog.Msg("KATYN_45_2_SQ_11_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

