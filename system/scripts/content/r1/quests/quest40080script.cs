//--- Melia Script -----------------------------------------------------------
// Working on the Landfill (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sergeant Tadas.
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

[QuestScript(40080)]
public class Quest40080Script : QuestScript
{
	protected override void Load()
	{
		SetId(40080);
		SetName("Working on the Landfill (2)");
		SetDescription("Talk to Sergeant Tadas");

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("FARM47_4_SQ_010"));

		AddDialogHook("FARM47_TADAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_DOWN_SACK_D", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_4_SQ_020_ST", "FARM47_4_SQ_020", "I can do that much", "About the lacking manpower", "Reject dirty works"))
		{
			case 1:
				await dialog.Msg("FARM47_4_SQ_020_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_4_SQ_020_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/SCR_FARM47_4_SQ_020_COMP_MSG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

