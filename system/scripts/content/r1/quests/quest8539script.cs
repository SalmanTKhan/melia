//--- Melia Script -----------------------------------------------------------
// Out of Time...
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Allen.
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

[QuestScript(8539)]
public class Quest8539Script : QuestScript
{
	protected override void Load()
	{
		SetId(8539);
		SetName("Out of Time...");
		SetDescription("Talk to Watcher Allen");

		AddPrerequisite(new LevelPrerequisite(32));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("GELE573_ALLEN", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_KAROLINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE573_MQ_02_01", "GELE573_MQ_02", "I'll help", "I'll wait a little bit"))
		{
			case 1:
				await dialog.Msg("GELE573_MQ_02_01_R");
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

		await dialog.Msg("GELE573_MQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

