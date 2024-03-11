//--- Melia Script -----------------------------------------------------------
// Time Stops Along With the Season (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Ida.
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

[QuestScript(90116)]
public class Quest90116Script : QuestScript
{
	protected override void Load()
	{
		SetId(90116);
		SetName("Time Stops Along With the Season (3)");
		SetDescription("Talk to Chronomancer Ida");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_1_SQ_80"));

		AddDialogHook("MAPLE_25_1_AIDAS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_90_ST", "MAPLE_25_1_SQ_90", "I will relay it", "That's tough"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_90_AG");
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

		await dialog.Msg("MAPLE_25_1_SQ_90_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

