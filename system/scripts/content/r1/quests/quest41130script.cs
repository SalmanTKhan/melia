//--- Melia Script -----------------------------------------------------------
// Final Conclusion (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Barte.
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

[QuestScript(41130)]
public class Quest41130Script : QuestScript
{
	protected override void Load()
	{
		SetId(41130);
		SetName("Final Conclusion (3)");
		SetDescription("Talk to Barte");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_120"));

		AddDialogHook("PILGRIM_36_2_BARTE", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_130_ST", "PILGRIM_36_2_SQ_130", "I will let them know", "I am quitting on this"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_130_AC");
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

		await dialog.Msg("PILGRIM_36_2_SQ_130_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

