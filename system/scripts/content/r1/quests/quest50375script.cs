//--- Melia Script -----------------------------------------------------------
// Strange Sculpture (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
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

[QuestScript(50375)]
public class Quest50375Script : QuestScript
{
	protected override void Load()
	{
		SetId(50375);
		SetName("Strange Sculpture (1)");
		SetDescription("Talk to Owynia Dilben");

		AddPrerequisite(new LevelPrerequisite(381));

		AddDialogHook("NICO811_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO811_SUBQ1_START", "F_NICOPOLIS_81_1_SQ_01", "I'll help you.", "Sorry, I gotta go."))
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

		await dialog.Msg("NICO811_SUBQ1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

