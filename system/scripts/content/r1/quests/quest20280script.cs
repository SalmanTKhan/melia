//--- Melia Script -----------------------------------------------------------
// Moldyhorn of Nefrito Valley
//--- Description -----------------------------------------------------------
// Quest to Go to Nefrito Valley.
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

[QuestScript(20280)]
public class Quest20280Script : QuestScript
{
	protected override void Load()
	{
		SetId(20280);
		SetName("Moldyhorn of Nefrito Valley");
		SetDescription("Go to Nefrito Valley");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_2_SQ01_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(49));

		AddObjective("kill0", "Kill 1 Moldyhorn", new KillObjective(1, MonsterId.Boss_Moldyhorn));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("HUEVILLAGE_58_2_SQ01_NPC", "BeforeStart", BeforeStart);
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

