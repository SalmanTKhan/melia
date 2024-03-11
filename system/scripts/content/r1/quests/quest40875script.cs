//--- Melia Script -----------------------------------------------------------
// His Only Desire (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cleric Master.
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

[QuestScript(40875)]
public class Quest40875Script : QuestScript
{
	protected override void Load()
	{
		SetId(40875);
		SetName("His Only Desire (3)");
		SetDescription("Talk to the Cleric Master");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_030"));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_58_SQ_035_ST", "FLASH_58_SQ_035", "I will go back", "I will think about it for a while"))
		{
			case 1:
				await dialog.Msg("FLASH_58_SQ_035_ACC");
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

		await dialog.Msg("FLASH_58_SQ_035_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

