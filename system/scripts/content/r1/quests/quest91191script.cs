//--- Melia Script -----------------------------------------------------------
// Pokubu Fang wanted!
//--- Description -----------------------------------------------------------
// Quest to Check the notice at the Orsha Notice Board.
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

[QuestScript(91191)]
public class Quest91191Script : QuestScript
{
	protected override void Load()
	{
		SetId(91191);
		SetName("Pokubu Fang wanted!");
		SetDescription("Check the notice at the Orsha Notice Board");

		AddPrerequisite(new LevelPrerequisite(480));

		AddObjective("collect0", "Collect 20 Pokubu's Fang(s)", new CollectItemObjective("EP15_1_ABBEY1_SQ2_ITEM", 20));
		AddDrop("EP15_1_ABBEY1_SQ2_ITEM", 1f, 59771, 59777);

		AddReward(new ExpReward(3600000000, 3600000000));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY1_SQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_COLLECTION_SHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_ABBEY1_SQ2_DLG1", "EP15_1_ABBEY1_SQ2", "I'll get those Fangs.", "I need to take care of something else."))
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

		if (character.Inventory.HasItem("EP15_1_ABBEY1_SQ2_ITEM", 20))
		{
			character.Inventory.RemoveItem("EP15_1_ABBEY1_SQ2_ITEM", 20);
			await dialog.Msg("EP15_1_ABBEY1_SQ2_DLG2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

