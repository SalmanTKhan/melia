//--- Melia Script -----------------------------------------------------------
// Solve the problem
//--- Description -----------------------------------------------------------
// Quest to Talk to Gytis.
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

[QuestScript(50016)]
public class Quest50016Script : QuestScript
{
	protected override void Load()
	{
		SetId(50016);
		SetName("Solve the problem");
		SetDescription("Talk to Gytis");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("SIAULIAI_50_1_SQ_GYTIS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_090_select01", "SIAULIAI_50_1_SQ_090", "Tell him about the conditions", "Reject"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_090_selectnpc01");
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

		await dialog.Msg("SIAULIAI_50_1_SQ_090_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

