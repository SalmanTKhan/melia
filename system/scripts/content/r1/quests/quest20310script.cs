//--- Melia Script -----------------------------------------------------------
// The Secret of the Machine
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius at the Grand Corridor.
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

[QuestScript(20310)]
public class Quest20310Script : QuestScript
{
	protected override void Load()
	{
		SetId(20310);
		SetName("The Secret of the Machine");
		SetDescription("Talk to Bishop Aurelius at the Grand Corridor");

		AddPrerequisite(new LevelPrerequisite(140));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_MQ06"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL54_MQ01_PART1_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3640));

		AddDialogHook("CHATHEDRAL54_PART1_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_MQ01_PUZZLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_MQ01_PART1_select01", "CHATHEDRAL54_MQ01_PART1", "I will solve the secret", "I'll do it later"))
		{
			case 1:
				dialog.HideNPC("CHATHEDRAL54_PART1_BISHOP");
				dialog.UnHideNPC("CHATHEDRAL54_BISHOP_AFTER");
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

		ZoneServer.Instance.World.FindNPC("CHATHEDRAL53_MQ06_PUZZLE")?.PlayEffectLocal(character.Connection, "F_spin022_blue", 0.5f, "BOT");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Acquired Maven's key!");
		dialog.UnHideNPC("CHATHEDRAL54_PART1_BISHOP");
		await dialog.Msg("NoneFunc/CHATHEDRAL56_BISHOP_APPEAR");
		await dialog.Msg("CHATHEDRAL54_MQ01_PART1_succ01");
		dialog.HideNPC("CHATHEDRAL54_PART1_BISHOP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

