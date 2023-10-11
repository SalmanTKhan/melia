//--- Melia Script -----------------------------------------------------------
// Grace of Wealth [Pardoner Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Meet the Pardoner Master.
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

[QuestScript(17500)]
public class Quest17500Script : QuestScript
{
	protected override void Load()
	{
		SetId(17500);
		SetName("Grace of Wealth [Pardoner Advancement] (1)");
		SetDescription("Meet the Pardoner Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("JOB_PARDONER4_1", "BeforeStart", BeforeStart);
		AddDialogHook("FED_EQUIP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PARDONER4_1_ST", "JOB_PARDONER4_1", "I'll take on the assignment", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_PARDONER4_1_AC");
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

		await dialog.Msg("JOB_PARDONER4_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_PARDONER4_3");
	}
}

