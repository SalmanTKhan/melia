//--- Melia Script -----------------------------------------------------------
// The Planned Escape
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Aldona.
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

[QuestScript(60017)]
public class Quest60017Script : QuestScript
{
	protected override void Load()
	{
		SetId(60017);
		SetName("The Planned Escape");
		SetDescription("Talk to Kupole Aldona");

		AddPrerequisite(new LevelPrerequisite(157));
		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_05"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));

		AddDialogHook("VPRISON514_MQ_ALDONA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_VAKARINE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON514_MQ_06_01", "VPRISON514_MQ_06", "I will report about it", "I'll wait a little bit"))
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

		await dialog.Msg("VPRISON514_MQ_06_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

