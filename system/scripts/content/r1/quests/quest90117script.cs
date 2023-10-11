//--- Melia Script -----------------------------------------------------------
// Time Stops Along With the Season (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chronomancer Master.
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

[QuestScript(90117)]
public class Quest90117Script : QuestScript
{
	protected override void Load()
	{
		SetId(90117);
		SetName("Time Stops Along With the Season (4)");
		SetDescription("Talk to the Chronomancer Master");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_1_SQ_90"));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_BRONIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_100_ST", "MAPLE_25_1_SQ_100", "Why did you start investigating the autmumn leaves anomaly?", "My work is done so I'll be going now"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_100_AG");
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

		await dialog.Msg("MAPLE_25_1_SQ_100_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

