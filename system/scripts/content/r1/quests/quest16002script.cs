//--- Melia Script -----------------------------------------------------------
// Learn Wizard Attributes
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

[QuestScript(16002)]
public class Quest16002Script : QuestScript
{
	protected override void Load()
	{
		SetId(16002);
		SetName("Learn Wizard Attributes");
		SetDescription("Talk to the Wizard Master");

		AddPrerequisite(new LevelPrerequisite(3));

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TUTO_WIZARD_TECH_01", "TUTO_WIZARD_TECH", "Listen to the explanation about Attributes", "Skip the explanation"))
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

		await dialog.Msg("TUTO_WIZARD_TECH_03");
		// Func/SCR_TUTO_WIZARD_SUCC;
		dialog.ShowHelp("TUTO_ABILITYPOINT_TEAM_SHARE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

