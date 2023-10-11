//--- Melia Script -----------------------------------------------------------
// Guardian Purifying Device
//--- Description -----------------------------------------------------------
// Quest to Check the epitaph of the Royal Mausoleum.
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

[QuestScript(8211)]
public class Quest8211Script : QuestScript
{
	protected override void Load()
	{
		SetId(8211);
		SetName("Guardian Purifying Device");
		SetDescription("Check the epitaph of the Royal Mausoleum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA1F_MQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(81));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1620));

		AddDialogHook("ZACHA1F_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA1F_MQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA1F_MQ_02_01", "ZACHA1F_MQ_02", "Go to purify the corrupted Guardian", "I'll wait a little bit"))
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

