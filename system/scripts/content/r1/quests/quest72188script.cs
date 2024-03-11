//--- Melia Script -----------------------------------------------------------
// To 12F (2)
//--- Description -----------------------------------------------------------
// Quest to Move to the Rendezvous Point.
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

[QuestScript(72188)]
public class Quest72188Script : QuestScript
{
	protected override void Load()
	{
		SetId(72188);
		SetName("To 12F (2)");
		SetDescription("Move to the Rendezvous Point");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_89_MQ_80_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_70"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19500));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_03", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_04", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("STARTOWER_89_MQ_80_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

