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

[QuestScript(8423)]
public class Quest8423Script : QuestScript
{
	protected override void Load()
	{
		SetId(8423);
		SetName("Guardian Stone Statue's Warning");
		SetDescription("Read the epitaph");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA5F_EQ_05_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(94));

		AddObjective("kill0", "Kill 8 Mauros(s) or Medakia(s) or Rusrat(s)", new KillObjective(8, 400861, 400821, 400801));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1880));

		AddDialogHook("ZACHA5F_EQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA5F_EQ_05_select01", "ZACHA5F_EQ_05", "I'll defeat the corrupted guardians", "Ignore it"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

