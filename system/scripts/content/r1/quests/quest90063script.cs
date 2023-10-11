//--- Melia Script -----------------------------------------------------------
// Finding the Last Witness (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kind Owl Sculpture.
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

[QuestScript(90063)]
public class Quest90063Script : QuestScript
{
	protected override void Load()
	{
		SetId(90063);
		SetName("Finding the Last Witness (2)");
		SetDescription("Talk to Kind Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_8"));

		AddDialogHook("KATYN_45_3_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_AJEL4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_9_ST", "KATYN_45_3_SQ_9", "What do you have in mind?", "We should give up this investigation."))
		{
			case 1:
				await dialog.Msg("KATYN_45_3_SQ_9_AG");
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

		await dialog.Msg("KATYN_45_3_SQ_9_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

