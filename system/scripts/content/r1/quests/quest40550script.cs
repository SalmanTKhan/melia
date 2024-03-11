//--- Melia Script -----------------------------------------------------------
// Dead of the Dead (3)
//--- Description -----------------------------------------------------------
// Quest to Report to Adrijus.
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

[QuestScript(40550)]
public class Quest40550Script : QuestScript
{
	protected override void Load()
	{
		SetId(40550);
		SetName("Dead of the Dead (3)");
		SetDescription("Report to Adrijus");

		AddPrerequisite(new LevelPrerequisite(168));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_060"));

		AddObjective("collect0", "Collect 8 Bone Powder(s)", new CollectItemObjective("REMAINS37_1_SQ_070_ITEM_1", 8));
		AddDrop("REMAINS37_1_SQ_070_ITEM_1", 10f, 57596, 57622, 57620);

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5040));

		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_1_SQ_070_ST", "REMAINS37_1_SQ_070", "Tell him to return well", "Tell him that it won't be effective"))
		{
			case 1:
				await dialog.Msg("REMAINS37_1_SQ_070_AC");
				dialog.HideNPC("REMAINS37_1_ADRIJUS");
				await dialog.Msg("FadeOutIN/2500");
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

		if (character.Inventory.HasItem("REMAINS37_1_SQ_070_ITEM_1", 8))
		{
			character.Inventory.RemoveItem("REMAINS37_1_SQ_070_ITEM_1", 8);
			await dialog.Msg("REMAINS37_1_SQ_070_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_1_SQ_080");
	}
}

