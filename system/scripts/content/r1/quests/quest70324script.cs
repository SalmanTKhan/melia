//--- Melia Script -----------------------------------------------------------
// Splendid Spear Skills [Cataphract Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cataphract Master.
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

[QuestScript(70324)]
public class Quest70324Script : QuestScript
{
	protected override void Load()
	{
		SetId(70324);
		SetName("Splendid Spear Skills [Cataphract Advancement]");
		SetDescription("Talk to the Cataphract Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 30 Old Hook(s) or Hallowventer(s)", new KillObjective(30, 58145, 58143));

		AddDialogHook("JOB_2_CATAPHRACT_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CATAPHRACT_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_CATAPHRACT4_1_1", "JOB_2_CATAPHRACT4", "Learning is why I came here in the first place", "I will get it again later"))
		{
			case 1:
				await dialog.Msg("JOB_2_CATAPHRACT4_1_2");
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

