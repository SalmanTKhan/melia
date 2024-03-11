//--- Melia Script -----------------------------------------------------------
// Finding the Last Witness (1)
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

[QuestScript(90062)]
public class Quest90062Script : QuestScript
{
	protected override void Load()
	{
		SetId(90062);
		SetName("Finding the Last Witness (1)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_7"));

		AddDialogHook("KATYN_45_3_AJEL4", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_OWL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_8_ST", "KATYN_45_3_SQ_8", "I will come back with some answers", "I think we should rest for now."))
		{
			case 1:
				await dialog.Msg("KATYN_45_3_SQ_8_AG");
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

		await dialog.Msg("KATYN_45_3_SQ_8_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

