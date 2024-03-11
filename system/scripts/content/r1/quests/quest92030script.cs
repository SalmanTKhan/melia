//--- Melia Script -----------------------------------------------------------
// Extinct Mirtinas (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Baiga.
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

[QuestScript(92030)]
public class Quest92030Script : QuestScript
{
	protected override void Load()
	{
		SetId(92030);
		SetName("Extinct Mirtinas (3)");
		SetDescription("Talk to Baiga");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_F_SIAULIAI_5_MQ_04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(458));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_03"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_F_SIAULIAI_5_BAIGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("EP13_F_SIAULIAI_5_MQ_04_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

