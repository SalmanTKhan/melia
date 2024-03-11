//--- Melia Script -----------------------------------------------------------
// Legacy of the Royal Family (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ahylas Jonas.
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

[QuestScript(20167)]
public class Quest20167Script : QuestScript
{
	protected override void Load()
	{
		SetId(20167);
		SetName("Legacy of the Royal Family (2)");
		SetDescription("Talk to Ahylas Jonas");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_MQ_1"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("ROKAS24_CATALYST", 1));
		AddReward(new ItemReward("Vis", 21924));

		AddDialogHook("ROKAS24_ALCHEMIST", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS24_ALCHEMIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_MQ_2_select01", "ROKAS24_MQ_2", "I will get the Canyon Amalas", "I'd like to stop"))
		{
			case 1:
				await dialog.Msg("ROKAS24_MQ_2_startnpc01");
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

		await dialog.Msg("ROKAS24_MQ_2_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

