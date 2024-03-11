//--- Melia Script -----------------------------------------------------------
// Demon God Ragana (3)
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

[QuestScript(72247)]
public class Quest72247Script : QuestScript
{
	protected override void Load()
	{
		SetId(72247);
		SetName("Demon God Ragana (3)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(420));
		AddPrerequisite(new CompletedPrerequisite("EP12_PRELUDE_09"));

		AddReward(new ItemReward("card_Neringa", 1));

		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_106C", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_PRELUDE_NERINGA_ORSHA1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_PRELUDE_10_DLG01", "EP12_PRELUDE_10", "Tell her you'll see her in Orsha", "Say you don't need it"))
		{
			case 1:
				// Func/SCR_EP12_PRELUDE_NERINGA_DCAPITAL_106C_AFTER;
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

		await dialog.Msg("EP12_PRELUDE_10_DLG02");
		// Func/SCR_EP12_PRELUDE_NERINGA_ORSHA2_AFTER;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

