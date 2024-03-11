//--- Melia Script -----------------------------------------------------------
// Dagger's Owner
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90082)]
public class Quest90082Script : QuestScript
{
	protected override void Load()
	{
		SetId(90082);
		SetName("Dagger's Owner");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_11"), new CompletedPrerequisite("SIAULIAI_50_1_SQ_060"));

		AddDialogHook("KATYN_45_3_AJEL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_AJEL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_15_ST", "KATYN_45_3_SQ_15", "I remember experiencing something similar.", "I'm curious about it as well."))
		{
			case 1:
				await dialog.Msg("KATYN_45_3_SQ_15_AG");
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

		await dialog.Msg("KATYN_45_3_SQ_15_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

