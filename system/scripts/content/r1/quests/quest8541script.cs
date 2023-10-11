//--- Melia Script -----------------------------------------------------------
// To the Goddess at Once
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Kenneth.
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

[QuestScript(8541)]
public class Quest8541Script : QuestScript
{
	protected override void Load()
	{
		SetId(8541);
		SetName("To the Goddess at Once");
		SetDescription("Talk to Watcher Kenneth");

		AddPrerequisite(new LevelPrerequisite(32));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("GELE573_KENNETH", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_KAROLINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE573_MQ_04_01", "GELE573_MQ_04", "Alright", "It's too difficult"))
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

		await dialog.Msg("GELE573_MQ_04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

