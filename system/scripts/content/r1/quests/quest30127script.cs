//--- Melia Script -----------------------------------------------------------
// Learn Cleric Attributes
//--- Description -----------------------------------------------------------
// Quest to Talk with Cleric Submaster.
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

[QuestScript(30127)]
public class Quest30127Script : QuestScript
{
	protected override void Load()
	{
		SetId(30127);
		SetName("Learn Cleric Attributes");
		SetDescription("Talk with Cleric Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TUTO_2_CLERIC_TECH_select", "TUTO_2_CLERIC_TECH", "Listen to the explanation about Attributes", "Skip the explanation"))
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

