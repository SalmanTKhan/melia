//--- Melia Script -----------------------------------------------------------
// Vubbe Hunt Notice
//--- Description -----------------------------------------------------------
// Quest to Check the notice at the Notice Board.
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

[QuestScript(91190)]
public class Quest91190Script : QuestScript
{
	protected override void Load()
	{
		SetId(91190);
		SetName("Vubbe Hunt Notice");
		SetDescription("Check the notice at the Notice Board");

		AddPrerequisite(new LevelPrerequisite(480));

		AddObjective("kill0", "Kill 100 Vubbe Chaser(s) or Vubbe Rider(s)", new KillObjective(100, 59779, 59777));

		AddReward(new ExpReward(3600000000, 3600000000));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY1_SQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_SOLDIER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_ABBEY1_SQ1_DLG1", "EP15_1_ABBEY1_SQ1", "I'll hunt the Vubbes.", "I need to take care of something else."))
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

		await dialog.Msg("EP15_1_ABBEY1_SQ1_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

