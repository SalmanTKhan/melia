//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Misery
//--- Description -----------------------------------------------------------
// Quest to Investigate the Tree Root Crystals on the way to Altar Way..
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

[QuestScript(19610)]
public class Quest19610Script : QuestScript
{
	protected override void Load()
	{
		SetId(19610);
		SetName("Curse of Sloth - Misery");
		SetDescription("Investigate the Tree Root Crystals on the way to Altar Way.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM47_SQ_070_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(124));

		AddObjective("kill0", "Kill 1 Glutton", new KillObjective(1, MonsterId.Boss_Glutton));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("NECK01_133", 1));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST07", "BeforeStart", BeforeStart);
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

