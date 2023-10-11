//--- Melia Script -----------------------------------------------------------
// Necessary Power for the Kingdom [Paladin Advancement]
//--- Description -----------------------------------------------------------
// Quest to Paladin Submaster.
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

[QuestScript(70330)]
public class Quest70330Script : QuestScript
{
	protected override void Load()
	{
		SetId(70330);
		SetName("Necessary Power for the Kingdom [Paladin Advancement]");
		SetDescription("Paladin Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 40 Ellomago(s) or Old Hook(s) or Hallowventer(s)", new KillObjective(40, 58144, 58145, 58143));

		AddDialogHook("JOB_2_PALADIN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PALADIN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PALADIN4_1_1", "JOB_2_PALADIN4", "I am confident that I am full of power", "I want a simpler job"))
		{
			case 1:
				await dialog.Msg("JOB_2_PALADIN4_1_2");
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

