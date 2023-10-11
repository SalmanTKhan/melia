//--- Melia Script -----------------------------------------------------------
// Erecting Tombstones (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the blacksmith at Orsha.
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

[QuestScript(41707)]
public class Quest41707Script : QuestScript
{
	protected override void Load()
	{
		SetId(41707);
		SetName("Erecting Tombstones (3)");
		SetDescription("Talk to the blacksmith at Orsha");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_49_SQ_013"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("ORSHA_BLACKSMITH", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_49_ANTANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_017_ST", "PILGRIM_49_SQ_017", "Thank you ", "I have something to do"))
		{
			case 1:
				await dialog.Msg("PILGRIM_49_SQ_017_AC");
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

		await dialog.Msg("PILGRIM_49_SQ_017_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

