//--- Melia Script -----------------------------------------------------------
// Goddess Statue of Amolallul Hill
//--- Description -----------------------------------------------------------
// Quest to Suspicious Goddess Statue.
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

[QuestScript(19410)]
public class Quest19410Script : QuestScript
{
	protected override void Load()
	{
		SetId(19410);
		SetName("Goddess Statue of Amolallul Hill");
		SetDescription("Suspicious Goddess Statue");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN72_BOSS_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(109));
		AddPrerequisite(new CompletedPrerequisite("KATYN72_MQ_10"));

		AddObjective("kill0", "Kill 1 Corrupted", new KillObjective(1, MonsterId.Boss_Fallen_Statue));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_BOSS", "BeforeStart", BeforeStart);
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

