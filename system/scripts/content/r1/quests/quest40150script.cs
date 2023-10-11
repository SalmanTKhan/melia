//--- Melia Script -----------------------------------------------------------
// Desire for Normal Food (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Marius.
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

[QuestScript(40150)]
public class Quest40150Script : QuestScript
{
	protected override void Load()
	{
		SetId(40150);
		SetName("Desire for Normal Food (1)");
		SetDescription("Talk with Marius");

		AddPrerequisite(new LevelPrerequisite(84));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("FARM47_MARIUS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_DALIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_4_SQ_090_ST", "FARM47_4_SQ_090", "I'll deliver it for you", "Decline"))
		{
			case 1:
				await dialog.Msg("FARM47_4_SQ_090_AC");
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

		await dialog.Msg("FARM47_4_SQ_090_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

