//--- Melia Script -----------------------------------------------------------
// Formal Test [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hoplite Master.
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

[QuestScript(70310)]
public class Quest70310Script : QuestScript
{
	protected override void Load()
	{
		SetId(70310);
		SetName("Formal Test [Hoplite Advancement]");
		SetDescription("Talk to the Hoplite Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 30 Raffly(s)", new KillObjective(30, MonsterId.Raffly));

		AddDialogHook("JOB_2_HOPLITE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HOPLITE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HOPLITE3_1_1", "JOB_2_HOPLITE3", "Just tell me where to go", "I give up"))
		{
			case 1:
				await dialog.Msg("JOB_2_HOPLITE3_1_2");
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

