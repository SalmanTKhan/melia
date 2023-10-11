//--- Melia Script -----------------------------------------------------------
// Mercy and Salvation (3)
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

[QuestScript(20305)]
public class Quest20305Script : QuestScript
{
	protected override void Load()
	{
		SetId(20305);
		SetName("Mercy and Salvation (3)");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(137));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_MQ05"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL53_MQ06_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 51375));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_MQ06_PUZZLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_MQ06_select01", "CHATHEDRAL53_MQ06", "I will go to the Small Hall", "Decline"))
		{
			case 1:
				// Func/CHATHEDRAL53_MQ06_ITEM_RETURN;
				await dialog.Msg("CHATHEDRAL53_MQ06_AG");
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

		await dialog.Msg("NPCAin/CHATHEDRAL53_MQ06_PUZZLE/open/1");
		await Task.Delay(500);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Acquired Maven's key!");
		dialog.UnHideNPC("CHATHEDRAL54_PART1_BISHOP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/CHATHEDRAL53_MQ06_ITEM_RETURN;
		var dialog = new Dialog(character, null);
		dialog.Msg("CHATHEDRAL53_MQ06_AG");
	}
}

