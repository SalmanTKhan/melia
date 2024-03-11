//--- Melia Script -----------------------------------------------------------
// Sweet Dreams (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Raucous Owl Sculpture.
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

[QuestScript(90039)]
public class Quest90039Script : QuestScript
{
	protected override void Load()
	{
		SetId(90039);
		SetName("Sweet Dreams (1)");
		SetDescription("Talk to the Raucous Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_8"));

		AddObjective("collect0", "Collect 6 Ritual Pouch(s)", new CollectItemObjective("KATYN_45_1_SQ_9_ITEM2", 6));
		AddDrop("KATYN_45_1_SQ_9_ITEM2", 8f, 57915, 57919);

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9065));

		AddDialogHook("KATYN_45_1_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_OWL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_9_ST", "KATYN_45_1_SQ_9", "Alright, I'll help you", "My hands are tied at the moment."))
		{
			case 1:
				dialog.UnHideNPC("KATYN_45_1_SQ_9_STONE");
				await dialog.Msg("KATYN_45_1_SQ_9_AG");
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

		if (character.Inventory.HasItem("KATYN_45_1_SQ_9_ITEM2", 6) && character.Inventory.HasItem("KATYN_45_1_SQ_9_ITEM1", 6))
		{
			character.Inventory.RemoveItem("KATYN_45_1_SQ_9_ITEM2", 6);
			character.Inventory.RemoveItem("KATYN_45_1_SQ_9_ITEM1", 6);
			dialog.HideNPC("KATYN_45_1_SQ_9_STONE");
			await dialog.Msg("KATYN_45_1_SQ_9_SU");
			ZoneServer.Instance.World.FindNPC("KATYN_45_1_OWL3")?.PlayEffectLocal(character.Connection, "F_light018_yellow", 2f, "MID");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

