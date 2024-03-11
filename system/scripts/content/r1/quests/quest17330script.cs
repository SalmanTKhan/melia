//--- Melia Script -----------------------------------------------------------
// Path of the Healer [Cleric Advancement](3)
//--- Description -----------------------------------------------------------
// Quest to Collect medicinal herbs.
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

[QuestScript(17330)]
public class Quest17330Script : QuestScript
{
	protected override void Load()
	{
		SetId(17330);
		SetName("Path of the Healer [Cleric Advancement](3)");
		SetDescription("Collect medicinal herbs");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_CLERIC4_2"));

		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_CLERIC4_3_ST");
		await Task.Delay(10000);
		dialog.HideNPC("JOB_CLERIC_GRASS");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

