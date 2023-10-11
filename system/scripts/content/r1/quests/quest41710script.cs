//--- Melia Script -----------------------------------------------------------
// Erecting Tombstones (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Antanas.
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

[QuestScript(41710)]
public class Quest41710Script : QuestScript
{
	protected override void Load()
	{
		SetId(41710);
		SetName("Erecting Tombstones (4)");
		SetDescription("Talk to Antanas");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_49_SQ_017"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM_49_ANTANAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_49_ANTANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_020_ST", "PILGRIM_49_SQ_020", "I will try", "Decline"))
		{
			case 1:
				await dialog.Msg("PILGRIM_49_SQ_020_AC");
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

		await dialog.Msg("PILGRIM_49_SQ_020_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

