//--- Melia Script -----------------------------------------------------------
// Prepare for the Season (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lumberjack Dowedas.
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

[QuestScript(90113)]
public class Quest90113Script : QuestScript
{
	protected override void Load()
	{
		SetId(90113);
		SetName("Prepare for the Season (2)");
		SetDescription("Talk with Lumberjack Dowedas");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_1_SQ_50"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("MAPLE_25_1_SQ_ITEM3", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("MAPLE_25_1_DOVYDAS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_DOVYDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_60_ST", "MAPLE_25_1_SQ_60", "I will check it out.", "Let me have some rest first."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_60_AG");
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

		await dialog.Msg("MAPLE_25_1_SQ_60_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

