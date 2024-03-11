//--- Melia Script -----------------------------------------------------------
// Purification of the Stream, Recovery of the Tree (3)
//--- Description -----------------------------------------------------------
// Quest to The appearance of an evil energy.
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

[QuestScript(19950)]
public class Quest19950Script : QuestScript
{
	protected override void Load()
	{
		SetId(19950);
		SetName("Purification of the Stream, Recovery of the Tree (3)");
		SetDescription("The appearance of an evil energy");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM52_SQ_090_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(133));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_081"));

		AddObjective("kill0", "Kill 1 Succubus", new KillObjective(1, MonsterId.Boss_Succubus));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("PILGRIM52_ITEM_09", 1));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM_SUCCUBUS", "BeforeStart", BeforeStart);
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

