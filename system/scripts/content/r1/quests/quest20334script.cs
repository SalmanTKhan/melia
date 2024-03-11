//--- Melia Script -----------------------------------------------------------
// To Pasala Altar
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20334)]
public class Quest20334Script : QuestScript
{
	protected override void Load()
	{
		SetId(20334);
		SetName("To Pasala Altar");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ05"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 11));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_MQ06_select01", "CHATHEDRAL56_MQ06", "I will go to Pasala Altar", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

