//--- Melia Script -----------------------------------------------------------
// Degree of Wizard [Wizard Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wizard Master.
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

[QuestScript(8400)]
public class Quest8400Script : QuestScript
{
	protected override void Load()
	{
		SetId(8400);
		SetName("Degree of Wizard [Wizard Advancement]");
		SetDescription("Talk to the Wizard Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("kill0", "Kill 15 Red Kepa(s)", new KillObjective(15, MonsterId.Onion_Red));

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WIZARD1_01", "JOB_WIZARD1", "I'll accept the test", "Decline"))
		{
			case 1:
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

		await dialog.Msg("JOB_WIZARD1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

