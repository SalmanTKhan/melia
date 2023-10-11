//--- Melia Script -----------------------------------------------------------
// Essence of Fire [Pyromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(1107)]
public class Quest1107Script : QuestScript
{
	protected override void Load()
	{
		SetId(1107);
		SetName("Essence of Fire [Pyromancer Advancement]");
		SetDescription("Talk to the Pyromancer Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PYROMANCER2_1_select1", "JOB_PYROMANCER2_1", "I will collect the energies of fire for you", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_PYROMANCER2_1_AG");
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

		await dialog.Msg("JOB_PYROMANCER2_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

