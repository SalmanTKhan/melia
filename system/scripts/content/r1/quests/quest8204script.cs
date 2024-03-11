//--- Melia Script -----------------------------------------------------------
// Dangerous Throneweaver (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sad Owl Sculpture.
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

[QuestScript(8204)]
public class Quest8204Script : QuestScript
{
	protected override void Load()
	{
		SetId(8204);
		SetName("Dangerous Throneweaver (1)");
		SetDescription("Talk to the Sad Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(109));

		AddObjective("collect0", "Collect 7 Ridimed Leaves(s)", new CollectItemObjective("KATYN72_KRUMABOLEG", 7));
		AddDrop("KATYN72_KRUMABOLEG", 10f, "Ridimed");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_SECTOR_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN72_SECTOR_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN72_MQ_05_01", "KATYN72_MQ_05", "Alright, I'll help you", "Why are the monsters destroying Owl Sculptures", "Just ignore it"))
		{
			case 1:
				await dialog.Msg("KATYN72_MQ_05_01_a");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("KATYN72_MQ_05_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("KATYN72_KRUMABOLEG", 7))
		{
			character.Inventory.RemoveItem("KATYN72_KRUMABOLEG", 7);
			await dialog.Msg("KATYN72_MQ_05_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN72_MQ_06");
	}
}

