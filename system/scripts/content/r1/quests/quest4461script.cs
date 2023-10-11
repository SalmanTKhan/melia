//--- Melia Script -----------------------------------------------------------
// Purify the Toxic Fumes in 1F
//--- Description -----------------------------------------------------------
// Quest to Talk to Vaidotas in the Mine.
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

[QuestScript(4461)]
public class Quest4461Script : QuestScript
{
	protected override void Load()
	{
		SetId(4461);
		SetName("Purify the Toxic Fumes in 1F");
		SetDescription("Talk to Vaidotas in the Mine");

		AddPrerequisite(new LevelPrerequisite(17));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_16"));

		AddReward(new ExpReward(45662, 45662));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 14));
		AddReward(new ItemReward("Vis", 2210));

		AddDialogHook("MINE_1_ALCHEMIST", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MINE_1_ALCHEMIST_select1", "MINE_1_ALCHEMIST", "Ask how to repair the purifier", "That seems difficult"))
		{
			case 1:
				await dialog.Msg("MINE_1_ALCHEMIST_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MINE_2_ALCHEMIST");
	}
}

