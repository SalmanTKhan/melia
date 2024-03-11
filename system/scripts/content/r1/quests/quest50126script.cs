//--- Melia Script -----------------------------------------------------------
// Rescue Edmundas (2)
//--- Description -----------------------------------------------------------
// Quest to Follow Rose into the Apega State Chamber.
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

[QuestScript(50126)]
public class Quest50126Script : QuestScript
{
	protected override void Load()
	{
		SetId(50126);
		SetName("Rescue Edmundas (2)");
		SetDescription("Follow Rose into the Apega State Chamber");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_2_MQ010"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("ABBEY642_ROZE02", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY642_ROZE02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_2_MQ020_startnpc01", "ABBAY_64_2_MQ020", "I'll go right away", "Let's find another solution"))
		{
			case 1:
				// Func/ABBEY642_MQ2_PARTY_STATE;
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

