//--- Melia Script -----------------------------------------------------------
// Back in time(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chronomancer Master.
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

[QuestScript(60200)]
public class Quest60200Script : QuestScript
{
	protected override void Load()
	{
		SetId(60200);
		SetName("Back in time(1)");
		SetDescription("Talk to the Chronomancer Master");

		AddPrerequisite(new LevelPrerequisite(308));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FIRETOWER691_PRE_1_1", "FIRETOWER691_PRE_1", "I'll help you", "I am tired now"))
		{
			case 1:
				await dialog.Msg("FIRETOWER691_PRE_1_1_1");
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

		await dialog.Msg("FIRETOWER691_PRE_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

