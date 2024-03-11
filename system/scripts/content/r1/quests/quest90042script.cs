//--- Melia Script -----------------------------------------------------------
// Training Camp Owl (1)
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

[QuestScript(90042)]
public class Quest90042Script : QuestScript
{
	protected override void Load()
	{
		SetId(90042);
		SetName("Training Camp Owl (1)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_8"));

		AddDialogHook("KATYN_45_2_AJEL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_AJEL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_1_ST", "KATYN_45_2_SQ_1", "Alright", "I need to prepare"))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_1_AG");
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

		await dialog.Msg("KATYN_45_2_SQ_1_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

