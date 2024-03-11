//--- Melia Script -----------------------------------------------------------
// Edmundas' Worry (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(50139)]
public class Quest50139Script : QuestScript
{
	protected override void Load()
	{
		SetId(50139);
		SetName("Edmundas' Worry (2)");
		SetDescription("Talk to Edmundas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_SQ010"));

		AddDialogHook("ABBEY643_EDMONDA04", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_WIZARD_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_3_SQ020_startnpc01", "ABBAY_64_3_SQ020", "I'll go see the Wizard Submaster", "I'll go later"))
		{
			case 1:
				await dialog.Msg("ABBAY_64_3_SQ020_AG");
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


		return HookResult.Break;
	}
}

