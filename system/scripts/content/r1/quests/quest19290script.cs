//--- Melia Script -----------------------------------------------------------
// Release the seal{nl}on the left of Collapsed Sanctum
//--- Description -----------------------------------------------------------
// Quest to Release the seal{nl}on the left of Collapsed Sanctum.
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

[QuestScript(19290)]
public class Quest19290Script : QuestScript
{
	protected override void Load()
	{
		SetId(19290);
		SetName("Release the seal{nl}on the left of Collapsed Sanctum");
		SetDescription("Release the seal{nl}on the left of Collapsed Sanctum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS25_REXIPHER6_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(1, MonsterId.Boss_BiteRegina));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("misc_gemExpStone01", 1));
		AddReward(new ItemReward("Vis", 16226));

		AddDialogHook("ROKAS25_SWITCH5", "BeforeStart", BeforeStart);
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

