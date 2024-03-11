//--- Melia Script -----------------------------------------------------------
// Legend of the Cold Iron [Cryomancer Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Master.
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

[QuestScript(1108)]
public class Quest1108Script : QuestScript
{
	protected override void Load()
	{
		SetId(1108);
		SetName("Legend of the Cold Iron [Cryomancer Advancement] (1)");
		SetDescription("Talk to the Cryomancer Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("MASTER_ICEMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CRYOMANCER2_1_select1", "JOB_CRYOMANCER2_1", "I'll go find the book", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_CRYOMANCER2_1_AG");
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

		await dialog.Msg("JOB_CRYOMANCER2_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_CRYOMANCER2_2");
	}
}

