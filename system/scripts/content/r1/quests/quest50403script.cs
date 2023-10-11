//--- Melia Script -----------------------------------------------------------
// Research Archives on Main Street
//--- Description -----------------------------------------------------------
// Quest to Investigate the Area Where Old Research Papers May Be Stored.
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

[QuestScript(50403)]
public class Quest50403Script : QuestScript
{
	protected override void Load()
	{
		SetId(50403);
		SetName("Research Archives on Main Street");
		SetDescription("Investigate the Area Where Old Research Papers May Be Stored");

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_03"));

		AddDialogHook("NICO813_SUBQ_SEAL2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_SEAL2", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("BalloonText/NICO813_SUBQ041_TXT1/5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

