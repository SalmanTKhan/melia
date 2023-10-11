//--- Melia Script -----------------------------------------------------------
// Demon soaked in the Woods (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sacred Owl Sculpture.
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

[QuestScript(8317)]
public class Quest8317Script : QuestScript
{
	protected override void Load()
	{
		SetId(8317);
		SetName("Demon soaked in the Woods (1)");
		SetDescription("Talk with the Sacred Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_07"));

		AddObjective("collect0", "Collect 5 Sacred Force Sculpture(s)", new CollectItemObjective("KATYN18_MQ_11_ITEM", 5));
		AddDrop("KATYN18_MQ_11_ITEM", 6f, "Fisherman_red");

		AddDialogHook("KATYN18_OWL_03", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_11_01", "KATYN18_MQ_11", "We propose to give help", "Cancel"))
		{
			case 1:
				await dialog.Msg("KATYN18_MQ_11_startnpc01");
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

		if (character.Inventory.HasItem("KATYN18_MQ_11_ITEM", 5))
		{
			character.Inventory.RemoveItem("KATYN18_MQ_11_ITEM", 5);
			await dialog.Msg("KATYN18_MQ_11_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_12");
	}
}

