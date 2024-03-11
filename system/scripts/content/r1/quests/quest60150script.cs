//--- Melia Script -----------------------------------------------------------
// Dangerous Mine
//--- Description -----------------------------------------------------------
// Quest to Check the Purifier in 3F.
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

[QuestScript(60150)]
public class Quest60150Script : QuestScript
{
	protected override void Load()
	{
		SetId(60150);
		SetName("Dangerous Mine");
		SetDescription("Check the Purifier in 3F");

		AddPrerequisite(new LevelPrerequisite(22));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 308));

		AddDialogHook("CMINE6_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("CMINE6_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CMINE6_RP_1_1", "CMINE6_RP_1", "I'll find the power", "Not really my problem"))
		{
			case 1:
				dialog.UnHideNPC("CMINE6_RP_1_OBJ");
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

