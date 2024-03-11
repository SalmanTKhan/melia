//--- Melia Script -----------------------------------------------------------
// Temporary Solution
//--- Description -----------------------------------------------------------
// Quest to Talk to Albina.
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

[QuestScript(40440)]
public class Quest40440Script : QuestScript
{
	protected override void Load()
	{
		SetId(40440);
		SetName("Temporary Solution");
		SetDescription("Talk to Albina");

		AddPrerequisite(new LevelPrerequisite(93));

		AddDialogHook("FARM47_ALBINA", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_ALBINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_080_ST", "FARM47_1_SQ_080", "I will help", "About the strange atmosphere", "I'm not interested"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_1_SQ_080_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_1_SQ_080_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

