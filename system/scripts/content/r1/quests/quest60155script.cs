//--- Melia Script -----------------------------------------------------------
// Camping Preparations
//--- Description -----------------------------------------------------------
// Quest to Talk with the merchant.
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

[QuestScript(60155)]
public class Quest60155Script : QuestScript
{
	protected override void Load()
	{
		SetId(60155);
		SetName("Camping Preparations");
		SetDescription("Talk with the merchant");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ010"));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("BRACKEN631_TRADESMAN06", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_TRADESMAN06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN631_RP_1_1", "BRACKEN631_RP_1", "I'll try to find them", "I have no idea what you are talking about."))
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


		return HookResult.Break;
	}
}

