//--- Melia Script -----------------------------------------------------------
// The Sculpture in Slove Intersection (1)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Sculpture.
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

[QuestScript(50386)]
public class Quest50386Script : QuestScript
{
	protected override void Load()
	{
		SetId(50386);
		SetName("The Sculpture in Slove Intersection (1)");
		SetDescription("Investigate the Sculpture");

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_02"));

		AddDialogHook("NICO811_DEVICE4", "BeforeStart", BeforeStart);
		AddDialogHook("NICO_811_SUBQ0241_OBJ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("BalloonText/NICO_811_SUBQ0241_MSG/7");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

