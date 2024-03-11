//--- Melia Script -----------------------------------------------------------
// Karuna Altar Key
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

[QuestScript(20313)]
public class Quest20313Script : QuestScript
{
	protected override void Load()
	{
		SetId(20313);
		SetName("Karuna Altar Key");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(141));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_MQ03_PART2"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL54_MQ04_PART2_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3666));

		AddDialogHook("CHATHEDRAL54_BISHOP_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_MQ04_PART2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_MQ04_PART2_select01", "CHATHEDRAL54_MQ04_PART2", "I will recharge the Holy Symbol of Spiritual Power", "About the divine magical power and the demons", "Tell him that it doesn't make sense to recharge magical power using demons"))
		{
			case 1:
				await dialog.Msg("CHATHEDRAL54_MQ04_PART2_AG");
				dialog.HideNPC("CHATHEDRAL54_BISHOP_AFTER");
				ZoneServer.Instance.World.FindNPC("CHATHEDRAL54_BISHOP_AFTER")?.PlayEffectLocal(character.Connection, "F_buff_basic025_white_line_2", 1f, "BOT");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CHATHEDRAL54_MQ04_PART2_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.UnHideNPC("CHATHEDRAL56_MQ_BISHOP");
		ZoneServer.Instance.World.FindNPC("CHATHEDRAL53_MQ06_PUZZLE")?.PlayEffectLocal(character.Connection, "F_spin022_blue", 0.5f, "BOT");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Acquired Maven's key!");
		// Func/CHATHEDRAL56_BISHOP_APPEAR;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

