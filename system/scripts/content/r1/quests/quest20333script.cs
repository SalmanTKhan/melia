//--- Melia Script -----------------------------------------------------------
// The Last Key
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

[QuestScript(20333)]
public class Quest20333Script : QuestScript
{
	protected override void Load()
	{
		SetId(20333);
		SetName("The Last Key");
		SetDescription("Talk to Bishop Aurelius");
		SetTrack(QuestStatus.Progress, QuestStatus.Complete, "CHATHEDRAL56_MQ05_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(159));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ04"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL56_SQ01_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 11));
		AddReward(new ItemReward("Vis", 4611));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56_MQ05_PUZZLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_MQ05_select01", "CHATHEDRAL56_MQ05", "I will find the key", "Give me some time"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		ZoneServer.Instance.World.FindNPC("CHATHEDRAL56_MQ05_PUZZLE")?.PlayEffectLocal(character.Connection, "F_spin022_blue", 0.5f, "BOT");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Acquired Maven's key!");
		await dialog.Msg("CHATHEDRAL56_MQ05_PUZZLE_ED");
		// Func/SCR_CHATHEDRAL56_MQ05_LAYER;
		// Func/CHATHEDRAL56_BISHOP_APPEAR;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

