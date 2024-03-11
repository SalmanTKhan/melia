//--- Melia Script -----------------------------------------------------------
// Secure Route to the Gateway of the Great King (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Commander Julian.
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

[QuestScript(4381)]
public class Quest4381Script : QuestScript
{
	protected override void Load()
	{
		SetId(4381);
		SetName("Secure Route to the Gateway of the Great King (1)");
		SetDescription("Talk to Commander Julian");

		AddPrerequisite(new LevelPrerequisite(121));

		AddDialogHook("THORN22_JULIAN", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_POULLTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_Q_10_select1", "THORN22_Q_10", "Sure, I'll help", "Ignore"))
		{
			case 1:
				await dialog.Msg("THORN22_Q_10_select1_a");
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

		await dialog.Msg("THORN22_Q_10_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

