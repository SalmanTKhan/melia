//--- Melia Script -----------------------------------------------------------
// The Watcher's Potential (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Rikke.
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

[QuestScript(8605)]
public class Quest8605Script : QuestScript
{
	protected override void Load()
	{
		SetId(8605);
		SetName("The Watcher's Potential (1)");
		SetDescription("Talk to Watcher Rikke");

		AddPrerequisite(new LevelPrerequisite(35));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 490));

		AddDialogHook("GELE574_REIKE", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_REIKE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE574_MQ_05_01", "GELE574_MQ_05", "Accept immediately", "It looks dangerous"))
		{
			case 1:
				await dialog.Msg("GELE574_MQ_05_01_AG");
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

		await dialog.Msg("GELE574_MQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

