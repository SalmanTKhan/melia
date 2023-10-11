//--- Melia Script -----------------------------------------------------------
// Learn Swordsman Attributes
//--- Description -----------------------------------------------------------
// Quest to Talk with the Swordsman Submaster.
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

[QuestScript(30124)]
public class Quest30124Script : QuestScript
{
	protected override void Load()
	{
		SetId(30124);
		SetName("Learn Swordsman Attributes");
		SetDescription("Talk with the Swordsman Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_SWORDMAN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SWORDMAN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TUTO_2_SWORDMAN_TECH_select", "TUTO_2_SWORDMAN_TECH", "Learn about the attributes", "Skip the explanation"))
		{
			case 1:
				dialog.ShowHelp("TUTO_TECH");
				// Func/TUTO_PIP_CLOSE_QUEST;
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

