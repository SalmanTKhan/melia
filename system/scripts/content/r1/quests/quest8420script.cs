//--- Melia Script -----------------------------------------------------------
// Guardian Stone Statue's Warning
//--- Description -----------------------------------------------------------
// Quest to Read the Royal Mausoleum gravestone.
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

[QuestScript(8420)]
public class Quest8420Script : QuestScript
{
	protected override void Load()
	{
		SetId(8420);
		SetName("Guardian Stone Statue's Warning");
		SetDescription("Read the Royal Mausoleum gravestone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA5F_EQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(93));

		AddObjective("kill0", "Kill 8 Venucelos(s)", new KillObjective(8, MonsterId.Dog_Of_King));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("ZACHA5F_EQ_02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA5F_EQ_02_select01", "ZACHA5F_EQ_02", "I'll defeat the corrupted guardians", "Run away"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

