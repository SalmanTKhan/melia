//--- Melia Script -----------------------------------------------------------
// Learn Swordsman Attributes
//--- Description -----------------------------------------------------------
// Quest to Talk to the Swordsman Master.
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

[QuestScript(15001)]
public class Quest15001Script : QuestScript
{
	protected override void Load()
	{
		SetId(15001);
		SetName("Learn Swordsman Attributes");
		SetDescription("Talk to the Swordsman Master");

		AddPrerequisite(new LevelPrerequisite(3));

		AddDialogHook("MASTER_SWORDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TUTO_SWORDMAN_TECH_01", "TUTO_SWORDMAN_TECH", "Learn about the attributes", "Skip the explanation"))
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

		await dialog.Msg("TUTO_SWORDMAN_TECH_03");
		// Func/SCR_TUTO_SWORDMAN_SUCC;
		dialog.ShowHelp("TUTO_ABILITYPOINT_TEAM_SHARE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

