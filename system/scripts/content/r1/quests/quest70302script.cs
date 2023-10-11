//--- Melia Script -----------------------------------------------------------
// The Possibilities of a Two-handed Sword [Highlander Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Highlander Submaster.
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

[QuestScript(70302)]
public class Quest70302Script : QuestScript
{
	protected override void Load()
	{
		SetId(70302);
		SetName("The Possibilities of a Two-handed Sword [Highlander Advancement] (2)");
		SetDescription("Talk with the Highlander Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_2_HIGHLANDER2_1"));

		AddObjective("kill0", "Kill 10 Woodin(s)", new KillObjective(10, MonsterId.Woodin));

		AddDialogHook("JOB_2_HIGHLANDER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HIGHLANDER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HIGHLANDER2_2_1", "JOB_2_HIGHLANDER2_2", "Ask what the next assignment is", "I will quit now"))
		{
			case 1:
				await dialog.Msg("JOB_2_HIGHLANDER2_2_2");
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


		return HookResult.Break;
	}
}

