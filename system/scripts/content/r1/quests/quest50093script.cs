//--- Melia Script -----------------------------------------------------------
// Rose's Friends (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Cassias.
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

[QuestScript(50093)]
public class Quest50093Script : QuestScript
{
	protected override void Load()
	{
		SetId(50093);
		SetName("Rose's Friends (3)");
		SetDescription("Talk to Traveling Merchant Cassias");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN_63_1_MQ040_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ030"));

		AddObjective("kill0", "Kill 9 Vubbe Chaser(s)", new KillObjective(9, MonsterId.Sec_Bubbe_Chaser));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 3654));

		AddDialogHook("BRACKEN631_TRADESMAN05", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_ROZE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_MQ040_startnpc01", "BRACKEN_63_1_MQ040", "Let's go back to the Herb Gatherers' Cabin", "Let's rest for a while."))
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

