//--- Melia Script -----------------------------------------------------------
// Eliminate the Small Gaps
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Sigita.
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

[QuestScript(60041)]
public class Quest60041Script : QuestScript
{
	protected override void Load()
	{
		SetId(60041);
		SetName("Eliminate the Small Gaps");
		SetDescription("Talk to Kupole Sigita");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_06"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON515_SQ_03_01", "VPRISON515_SQ_03", "I will get rid of it", "I need some more time"))
		{
			case 1:
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

		await dialog.Msg("VPRISON515_SQ_03_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

