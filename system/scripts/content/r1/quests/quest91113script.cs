//--- Melia Script -----------------------------------------------------------
// Detached Force
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(91113)]
public class Quest91113Script : QuestScript
{
	protected override void Load()
	{
		SetId(91113);
		SetName("Detached Force");
		SetDescription("Talk to General Ramin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE4_MQ_5_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(466));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_4"));

		AddObjective("kill0", "Kill 10 Grasme Bird(s) or Grasme Crow(s) or Grasme Raven(s)", new KillObjective(10, 59702, 59703, 59704));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29358));

		AddDialogHook("EP14_1_FCASTLE4_MQ_2_NPC1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE4_MQ_5_SNPC_DLG1", "EP14_1_FCASTLE4_MQ_5", "I'll follow your order", "I need to prepare to follow your order"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE4_MQ_5_SNPC_DLG2");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

