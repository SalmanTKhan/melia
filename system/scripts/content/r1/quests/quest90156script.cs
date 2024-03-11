//--- Melia Script -----------------------------------------------------------
// Leadership Training [Templar Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(90156)]
public class Quest90156Script : QuestScript
{
	protected override void Load()
	{
		SetId(90156);
		SetName("Leadership Training [Templar Advancement]");
		SetDescription("Talk to Knight Commander Uska");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_TEMPLAR_8_1_ST", "JOB_TEMPLAR_8_1", "I am ready to start at any moment.", "I am not ready yet."))
		{
			case 1:
				await dialog.Msg("JOB_TEMPLAR_8_1_AG");
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

		await dialog.Msg("JOB_TEMPLAR_8_1_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

