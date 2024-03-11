//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (3)
//--- Description -----------------------------------------------------------
// Quest to Baiga wants you to meet him in the Second Hall.{nl}Go see Baiga in the Second Hall..
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

[QuestScript(80456)]
public class Quest80456Script : QuestScript
{
	protected override void Load()
	{
		SetId(80456);
		SetName("Root of the Divine Tree (3)");
		SetDescription("Baiga wants you to meet him in the Second Hall.{nl}Go see Baiga in the Second Hall.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_CASTLE_99_MQ_03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(431));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_02"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24998));

		AddDialogHook("F_CASTLE_99_MQ_03_TRIGGER", "BeforeStart", BeforeStart);
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

