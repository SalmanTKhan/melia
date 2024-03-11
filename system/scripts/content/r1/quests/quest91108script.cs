//--- Melia Script -----------------------------------------------------------
// Demon's Defense Plan (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91108)]
public class Quest91108Script : QuestScript
{
	protected override void Load()
	{
		SetId(91108);
		SetName("Demon's Defense Plan (6)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE3_MQ_8_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(464));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE3_MQ_7"));

		AddObjective("kill0", "Kill 1 Giant Blickferret Tent", new KillObjective(1, MonsterId.Episode14_1_Boss_Bleakferret_Tent));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29232));

		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE3_MQ_8_SNPC_DLG1", "EP14_1_FCASTLE3_MQ_8", "I'm ready", "Wait for a while"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE3_MQ_8_SNPC_DLG2");
				dialog.UnHideNPC("EP14_1_FCASTLE3_MQ_8_HIDDEN");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

