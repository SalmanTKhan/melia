//--- Melia Script -----------------------------------------------------------
// Bishop Urbonas' Whereabouts (3)
//--- Description -----------------------------------------------------------
// Quest to Defeat the incoming demons.
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

[QuestScript(60117)]
public class Quest60117Script : QuestScript
{
	protected override void Load()
	{
		SetId(60117);
		SetName("Bishop Urbonas' Whereabouts (3)");
		SetDescription("Defeat the incoming demons");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON621_MQ_03_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON621_MQ_02"));

		AddObjective("kill0", "Kill 9 Blue Dumaro(s) or Blue Wendigo(s)", new KillObjective(9, 57991, 58002));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("PRISON621_MQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_PRANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

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

