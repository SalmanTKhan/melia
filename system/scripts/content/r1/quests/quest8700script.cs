//--- Melia Script -----------------------------------------------------------
// The Spotlight [Swordsman Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Swordsman Master.
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

[QuestScript(8700)]
public class Quest8700Script : QuestScript
{
	protected override void Load()
	{
		SetId(8700);
		SetName("The Spotlight [Swordsman Advancement]");
		SetDescription("Meet the Swordsman Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_SWORDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SWORDMAN4_1_01", "JOB_SWORDMAN4_1", "I'll take the test", "Decline"))
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

		await dialog.Msg("JOB_SWORDMAN4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

