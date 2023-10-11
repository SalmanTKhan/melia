//--- Melia Script -----------------------------------------------------------
// Archery Test [Mergen Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Mergen Master.
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

[QuestScript(90164)]
public class Quest90164Script : QuestScript
{
	protected override void Load()
	{
		SetId(90164);
		SetName("Archery Test [Mergen Advancement]");
		SetDescription("Talk with the Mergen Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("MERGEN_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MERGEN_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_MERGEN_8_1_ST", "JOB_MERGEN_8_1", "I am ready", "I need some time to think about it."))
		{
			case 1:
				await dialog.Msg("JOB_MERGEN_8_1_AG");
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

		await dialog.Msg("JOB_MERGEN_8_1_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

