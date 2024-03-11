//--- Melia Script -----------------------------------------------------------
// Release the seal{nl}on the road to the Collapsed Sanctum
//--- Description -----------------------------------------------------------
// Quest to Release the seal{nl}on the road to the Collapsed Sanctum.
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

[QuestScript(19280)]
public class Quest19280Script : QuestScript
{
	protected override void Load()
	{
		SetId(19280);
		SetName("Release the seal{nl}on the road to the Collapsed Sanctum");
		SetDescription("Release the seal{nl}on the road to the Collapsed Sanctum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS25_REXIPHER4_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 3 Canyon Area Device 6(s)", new KillObjective(3, MonsterId.Npc_Rokas_7));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_SWITCH3", "BeforeStart", BeforeStart);
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

