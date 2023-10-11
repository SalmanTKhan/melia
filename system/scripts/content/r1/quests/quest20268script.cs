//--- Melia Script -----------------------------------------------------------
// The Attack of the Infro Holders
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Bronius.
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

[QuestScript(20268)]
public class Quest20268Script : QuestScript
{
	protected override void Load()
	{
		SetId(20268);
		SetName("The Attack of the Infro Holders");
		SetDescription("Talk to Believer Bronius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN21_MQ01_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 6 Chafperor(s) or Infro Holder Shaman(s)", new KillObjective(6, 41268, 57598));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BELIEVER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN21_MQ01_select01", "THORN21_MQ01", "I will protect you", "It will be okay if you hide "))
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

		await dialog.Msg("THORN21_MQ01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

