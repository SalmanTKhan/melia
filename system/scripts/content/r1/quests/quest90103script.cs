//--- Melia Script -----------------------------------------------------------
// A Mediator is Born (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Aeglei.
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

[QuestScript(90103)]
public class Quest90103Script : QuestScript
{
	protected override void Load()
	{
		SetId(90103);
		SetName("A Mediator is Born (3)");
		SetDescription("Talk to Kupole Aeglei");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_80"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("MAPLE_25_3_EGLE", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_EGLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_90_ST", "MAPLE_25_3_SQ_90", "I'll go there", "Let me have some rest first."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_90_AG");
				dialog.HideNPC("MAPLE_25_3_LINA");
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

		await dialog.Msg("MAPLE_25_3_SQ_90_SU");
		dialog.HideNPC("MAPLE_25_3_SQ_90");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

