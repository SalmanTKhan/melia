//--- Melia Script -----------------------------------------------------------
// Comforting Them
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Mihail.
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

[QuestScript(70447)]
public class Quest70447Script : QuestScript
{
	protected override void Load()
	{
		SetId(70447);
		SetName("Comforting Them");
		SetDescription("Talk to Revelator Mihail");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE65_3_MQ08_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ07"));

		AddObjective("kill0", "Kill 1 Red Lavenzard", new KillObjective(1, MonsterId.Boss_Rambandgad_Red));

		AddReward(new ExpReward(368565, 368565));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 23520));

		AddDialogHook("CASTLE653_MQ_07_2", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_07_2", "BeforeEnd", BeforeEnd);
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

