//--- Melia Script -----------------------------------------------------------
// For the Sacred Mission [Cleric Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Cleric Submaster.
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

[QuestScript(70304)]
public class Quest70304Script : QuestScript
{
	protected override void Load()
	{
		SetId(70304);
		SetName("For the Sacred Mission [Cleric Advancement]");
		SetDescription("Talk with Cleric Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 15 Pokubu(s) or Pokuborn(s)", new KillObjective(15, 58010, 58091));

		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_CLERIC2_1_1", "JOB_2_CLERIC2", "Sure, I'll help", "I have some other important task"))
		{
			case 1:
				await dialog.Msg("JOB_2_CLERIC2_1_2");
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

