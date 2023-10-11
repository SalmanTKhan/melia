//--- Melia Script -----------------------------------------------------------
// The Feline Post Town Case (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Auguste Dupin.
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

[QuestScript(50393)]
public class Quest50393Script : QuestScript
{
	protected override void Load()
	{
		SetId(50393);
		SetName("The Feline Post Town Case (7)");
		SetDescription("Talk to Auguste Dupin");

		AddPrerequisite(new LevelPrerequisite(384));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_06"));

		AddObjective("collect0", "Collect 13 Ingredy Powder(s)", new CollectItemObjective("NICOPOLIS_812_SUBQ7_ITEM1", 13));
		AddDrop("NICOPOLIS_812_SUBQ7_ITEM1", 9f, 59158, 59157);

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 25000));

		AddDialogHook("NICO812_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICOPOLIS812_SQ07_START1", "F_NICOPOLIS_81_2_SQ_07", "I'll go looking for Ingredy Powder", "Find somebody else to do it."))
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

		if (character.Inventory.HasItem("NICOPOLIS_812_SUBQ7_ITEM1", 13))
		{
			character.Inventory.RemoveItem("NICOPOLIS_812_SUBQ7_ITEM1", 13);
			await dialog.Msg("NICOPOLIS812_SQ07_SUCC1");
			await dialog.Msg("FadeOutIN/1000");
			await dialog.Msg("NICOPOLIS812_SQ07_SUCC2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

