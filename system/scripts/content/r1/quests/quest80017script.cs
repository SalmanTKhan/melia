//--- Melia Script -----------------------------------------------------------
// I Won't Give It To Them (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Carlyle's Spirit.
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

[QuestScript(80017)]
public class Quest80017Script : QuestScript
{
	protected override void Load()
	{
		SetId(80017);
		SetName("I Won't Give It To Them (2)");
		SetDescription("Talk to Carlyle's Spirit");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_08"));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_2_SQ_09_start", "CATACOMB_33_2_SQ_09", "I will burn them", "It is too good to do that"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

