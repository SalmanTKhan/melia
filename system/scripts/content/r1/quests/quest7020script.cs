//--- Melia Script -----------------------------------------------------------
// Seal of the Royal Family (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Disciple of Gustas.
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

[QuestScript(7020)]
public class Quest7020Script : QuestScript
{
	protected override void Load()
	{
		SetId(7020);
		SetName("Seal of the Royal Family (2)");
		SetDescription("Talk to the Disciple of Gustas");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_REXIPHER1"));

		AddDialogHook("ROKAS25_REXIPHER3", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_REXIPHER5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_REXIPHER4_select1", "ROKAS25_REXIPHER4", "I will unleash the seal", "I won't do it anymore"))
		{
			case 1:
				await dialog.Msg("ROKAS25_REXIPHER4_AC");
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

		await dialog.Msg("ROKAS25_REXIPHER4_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

