//--- Melia Script -----------------------------------------------------------
// Guilty Conscience [Sapper Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(1081)]
public class Quest1081Script : QuestScript
{
	protected override void Load()
	{
		SetId(1081);
		SetName("Guilty Conscience [Sapper Advancement] (3)");
		SetDescription("Talk to the Sapper Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_SAPPER2_2"));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("Vis", 1000))
		{
			character.Inventory.RemoveItem("Vis", 1000);
			await dialog.Msg("JOB_SAPPER2_3_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

