//--- Melia Script -----------------------------------------------------------
// Mercy and Salvation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20304)]
public class Quest20304Script : QuestScript
{
	protected override void Load()
	{
		SetId(20304);
		SetName("Mercy and Salvation (2)");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(137));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_MQ04"));

		AddObjective("collect0", "Collect 1 Relic of Salvation", new CollectItemObjective("CHATHEDRAL53_MQ05_ITEM", 1));
		AddDrop("CHATHEDRAL53_MQ05_ITEM", 1f, "loftlem_blue");

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_MQ05_select01", "CHATHEDRAL53_MQ05", "Ask him what to do", "Tell him that there is nothing that can be done for the ones missed"))
		{
			case 1:
				await dialog.Msg("CHATHEDRAL53_MQ05_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CHATHEDRAL53_MQ06");
	}
}

