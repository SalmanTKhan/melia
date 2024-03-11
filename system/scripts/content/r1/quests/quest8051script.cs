//--- Melia Script -----------------------------------------------------------
// Seal of the Royal Family (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gustas Jonas.
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

[QuestScript(8051)]
public class Quest8051Script : QuestScript
{
	protected override void Load()
	{
		SetId(8051);
		SetName("Seal of the Royal Family (4)");
		SetDescription("Talk to Gustas Jonas");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_REXIPHER6"));

		AddDialogHook("ROKAS25_REXIPHER5", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_REXIPHER5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_TO_26_ZACHA01_01", "ROKAS25_TO_26_ZACHA01", "I will unleash the seal of the divine place", "About King Zachariel's seal", "Decline"))
		{
			case 1:
				await dialog.Msg("ROKAS25_TO_26_ZACHA01_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS25_TO_26_ZACHA01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS25_TO_26_ZACHA01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

