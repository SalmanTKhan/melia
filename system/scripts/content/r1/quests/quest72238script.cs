//--- Melia Script -----------------------------------------------------------
// Creeping Darkness (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72238)]
public class Quest72238Script : QuestScript
{
	protected override void Load()
	{
		SetId(72238);
		SetName("Creeping Darkness (1)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(420));

		AddDialogHook("EP12_PRELUDE_NERINGA_ORSHA1", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_PRELUDE_NERINGA_ORSHA1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_PRELUDE_01_DLG01", "EP12_PRELUDE_01", "Say you will go", "Say not yet"))
		{
			case 1:
				await dialog.Msg("EP12_PRELUDE_01_DLG02");
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

		// Func/SCR_EP12_PRELUDE_NERINGA_ORSHA1_AFTER;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

