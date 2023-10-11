//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (1)
//--- Description -----------------------------------------------------------
// Quest to Follow the faint sound.
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

[QuestScript(50316)]
public class Quest50316Script : QuestScript
{
	protected override void Load()
	{
		SetId(50316);
		SetName("I Can Hear You Singing (1)");
		SetDescription("Follow the faint sound");

		AddPrerequisite(new LevelPrerequisite(344));

		AddDialogHook("WTREES221_SUBQ_TREE1_IN", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("WTREES22_1_SUBQ1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

