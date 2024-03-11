//--- Melia Script -----------------------------------------------------------
// Protect the Heritage (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Raymond.
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

[QuestScript(20201)]
public class Quest20201Script : QuestScript
{
	protected override void Load()
	{
		SetId(20201);
		SetName("Protect the Heritage (2)");
		SetDescription("Talk to Epigraphist Raymond");

		AddPrerequisite(new LevelPrerequisite(96));
		AddPrerequisite(new CompletedPrerequisite("REMAIN37_MQ04"));

		AddObjective("collect0", "Collect 10 Carbonized Tombstone Fragment(s)", new CollectItemObjective("REMAINS37_MSTONE_03", 10));
		AddDrop("REMAINS37_MSTONE_03", 10f, "TreeAmbulo");

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 23040));

		AddDialogHook("REMAIN37_RAYMOND", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_RAYMOND", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_MQ05_01", "REMAIN37_MQ05", "I will try", "It's too dangerous"))
		{
			case 1:
				await dialog.Msg("REMAIN37_MQ05_AG");
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

		if (character.Inventory.HasItem("REMAINS37_MSTONE_03", 10))
		{
			character.Inventory.RemoveItem("REMAINS37_MSTONE_03", 10);
			await dialog.Msg("REMAIN37_MQ05");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

