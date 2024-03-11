//--- Melia Script -----------------------------------------------------------
// The Great Chancellor
//--- Description -----------------------------------------------------------
// Quest to Talk with Royal Army Guard Rofdel.
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

[QuestScript(8844)]
public class Quest8844Script : QuestScript
{
	protected override void Load()
	{
		SetId(8844);
		SetName("The Great Chancellor");
		SetDescription("Talk with Royal Army Guard Rofdel");

		AddPrerequisite(new LevelPrerequisite(193));

		AddReward(new ExpReward(1189715, 1189715));
		AddReward(new ItemReward("expCard10", 1));
		AddReward(new ItemReward("Vis", 71796));

		AddDialogHook("FLASH63_ROFHDEL", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_ROFHDEL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_SQ_12_01", "FLASH63_SQ_12", "I will cover for you", "Tell him that you would reject irrelevant tasks"))
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

		await dialog.Msg("FLASH63_SQ_12_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

