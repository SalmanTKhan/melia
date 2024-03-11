//--- Melia Script -----------------------------------------------------------
// Mercy and Salvation (1)
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

[QuestScript(20303)]
public class Quest20303Script : QuestScript
{
	protected override void Load()
	{
		SetId(20303);
		SetName("Mercy and Salvation (1)");
		SetDescription("Talk to Bishop Aurelius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL53_MQ04_TRACK", "CHATHEDRAL53_MQ04_PG");

		AddPrerequisite(new LevelPrerequisite(137));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_MQ03"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL53_MQ04_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_MQ04_HINT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_MQ04_select01", "CHATHEDRAL53_MQ04", "I will look for the divine artifacts of the mercy", "Decline"))
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "A teardrop-shaped jewel appeared from the device");
		// Func/CHATHEDRAL56_BISHOP_APPEAR;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CHATHEDRAL53_MQ05");
	}
}

