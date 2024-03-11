//--- Melia Script -----------------------------------------------------------
// Guardian Stone Statue's Warning
//--- Description -----------------------------------------------------------
// Quest to Read the epitaph.
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

[QuestScript(8419)]
public class Quest8419Script : QuestScript
{
	protected override void Load()
	{
		SetId(8419);
		SetName("Guardian Stone Statue's Warning");
		SetDescription("Read the epitaph");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA5F_EQ_01_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(93));

		AddObjective("kill0", "Kill 7 Venucelos(s)", new KillObjective(7, MonsterId.Dog_Of_King));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("ZACHA5F_EQ_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA5F_EQ_01_select", "ZACHA5F_EQ_01", "I'll defeat the corrupted guardians", "Ignore"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

