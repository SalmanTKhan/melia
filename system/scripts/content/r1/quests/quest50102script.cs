//--- Melia Script -----------------------------------------------------------
// Where Did Everybody Go? (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tess.
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

[QuestScript(50102)]
public class Quest50102Script : QuestScript
{
	protected override void Load()
	{
		SetId(50102);
		SetName("Where Did Everybody Go? (4)");
		SetDescription("Talk to Tess");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN_63_2_MQ040_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_MQ030"));

		AddObjective("kill0", "Kill 6 Vubbe Chaser(s) or Lapasape Mage(s)", new KillObjective(6, 103023, 57640));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 4480));

		AddDialogHook("BRACKEN632_TOWN_PEAPLE", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_TOWN_PEAPLE_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_2_MQ040_startnpc01", "BRACKEN_63_2_MQ040", "Don't worry, I'm not a demon", "Let's wait until things cool down a little"))
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

