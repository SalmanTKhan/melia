//--- Melia Script -----------------------------------------------------------
// The price of life
//--- Description -----------------------------------------------------------
// Quest to Talk to Kedora Alliance Merchant Alta.
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

[QuestScript(60220)]
public class Quest60220Script : QuestScript
{
	protected override void Load()
	{
		SetId(60220);
		SetName("The price of life");
		SetDescription("Talk to Kedora Alliance Merchant Alta");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_9"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQB_3_1", "LSCAVE551_SQB_3", "I will check it out.", "It's useless"))
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

		await dialog.Msg("LSCAVE551_SQB_3_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

