//--- Melia Script -----------------------------------------------------------
// Destroying the Obelisks (4)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Obelisk.
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

[QuestScript(72234)]
public class Quest72234Script : QuestScript
{
	protected override void Load()
	{
		SetId(72234);
		SetName("Destroying the Obelisks (4)");
		SetDescription("Investigate the Obelisk");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE95_MAIN05_BEFORE_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(398));
		AddPrerequisite(new CompletedPrerequisite("CASTLE95_MAIN04"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 21041));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE95_OBELISK_02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}
