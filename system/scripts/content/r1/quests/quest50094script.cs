//--- Melia Script -----------------------------------------------------------
// Vendor's Lost Baggage
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Andres.
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

[QuestScript(50094)]
public class Quest50094Script : QuestScript
{
	protected override void Load()
	{
		SetId(50094);
		SetName("Vendor's Lost Baggage");
		SetDescription("Talk to Traveling Merchant Andres");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ010"));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));
		AddReward(new ItemReward("Drug_SP1_Q", 15));

		AddDialogHook("BRACKEN631_TRADESMAN02", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_TRADESMAN02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_SQ010_startnpc01", "BRACKEN_63_1_SQ010", "I will find it for you", "I feel very sorry for what happened"))
		{
			case 1:
				await dialog.Msg("BRACKEN_63_1_SQ010_AG");
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

