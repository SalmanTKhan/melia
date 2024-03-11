//--- Melia Script -----------------------------------------------------------
// Learn Archer Attributes
//--- Description -----------------------------------------------------------
// Quest to Talk to the Archer Master.
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

[QuestScript(17001)]
public class Quest17001Script : QuestScript
{
	protected override void Load()
	{
		SetId(17001);
		SetName("Learn Archer Attributes");
		SetDescription("Talk to the Archer Master");

		AddPrerequisite(new LevelPrerequisite(3));

		AddDialogHook("MASTER_ARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TUTO_ARCHER_TECH_01", "TUTO_ARCHER_TECH", "Listen to the explanation about Attributes", "Skip the explanation"))
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

		await dialog.Msg("TUTO_ARCHER_TECH_03");
		// Func/SCR_TUTO_ARCHER_SUCC;
		dialog.ShowHelp("TUTO_ABILITYPOINT_TEAM_SHARE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

