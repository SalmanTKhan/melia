//--- Melia Script -----------------------------------------------------------
// Frost Tome [Cryomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Submaster.
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

[QuestScript(30082)]
public class Quest30082Script : QuestScript
{
	protected override void Load()
	{
		SetId(30082);
		SetName("Frost Tome [Cryomancer Advancement]");
		SetDescription("Talk to the Cryomancer Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_CRYOMANCER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CRYOMANCER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_CRYOMANCER_3_1_select", "JOB_2_CRYOMANCER_3_1", "How can I handle the cold energy more proficiently?", "I'll come back next time, then"))
		{
			case 1:
				await dialog.Msg("JOB_2_CRYOMANCER_3_1_agree");
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

		await dialog.Msg("JOB_2_CRYOMANCER_3_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

