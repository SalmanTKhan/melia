//--- Melia Script -----------------------------------------------------------
// Hidden Treasure Chest
//--- Description -----------------------------------------------------------
// Quest to Find the hidden treasure.
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

[QuestScript(8421)]
public class Quest8421Script : QuestScript
{
	protected override void Load()
	{
		SetId(8421);
		SetName("Hidden Treasure Chest");
		SetDescription("Find the hidden treasure");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA5F_EQ_03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(94));

		AddObjective("kill0", "Kill 7 Medakia(s)", new KillObjective(7, MonsterId.Schlesien_Darkmage));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1880));

		AddDialogHook("ZACHA5F_EQ_03", "BeforeStart", BeforeStart);
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

