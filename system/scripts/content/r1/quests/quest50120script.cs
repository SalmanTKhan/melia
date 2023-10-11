//--- Melia Script -----------------------------------------------------------
// The Rescue (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Goss.
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

[QuestScript(50120)]
public class Quest50120Script : QuestScript
{
	protected override void Load()
	{
		SetId(50120);
		SetName("The Rescue (4)");
		SetDescription("Talk to Monk Goss");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBAY_64_1_MQ040_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_MQ030"));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("ABBEY641_MONK02", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_MONK03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_MQ040_startnpc01", "ABBAY_64_1_MQ040", "Alright", "Please give me some time to prepare"))
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


		return HookResult.Break;
	}
}

