//--- Melia Script -----------------------------------------------------------
// Dangerous Throneweaver (2)
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

[QuestScript(8205)]
public class Quest8205Script : QuestScript
{
	protected override void Load()
	{
		SetId(8205);
		SetName("Dangerous Throneweaver (2)");
		SetDescription("Talk to the Sad Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(109));
		AddPrerequisite(new CompletedPrerequisite("KATYN72_MQ_05"));

		AddObjective("collect0", "Collect 12 Sakmoli Roots(s)", new CollectItemObjective("KATYN72_POKU_CORPSE", 12));
		AddDrop("KATYN72_POKU_CORPSE", 10f, "Sakmoli");

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

		switch (await dialog.Select("KATYN72_MQ_06_01", "KATYN72_MQ_06", "I will get Sakmoli Roots", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("KATYN72_MQ_06_01_R");
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

		if (character.Inventory.HasItem("KATYN72_POKU_CORPSE", 12))
		{
			character.Inventory.RemoveItem("KATYN72_POKU_CORPSE", 12);
			await dialog.Msg("KATYN72_MQ_06_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN7_2_ADD_BOSS_01");
	}
}

