//--- Melia Script -----------------------------------------------------------
// Sculptor's Trial (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Test Instructor Owl.
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

[QuestScript(8334)]
public class Quest8334Script : QuestScript
{
	protected override void Load()
	{
		SetId(8334);
		SetName("Sculptor's Trial (6)");
		SetDescription("Talk to the Test Instructor Owl");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_MQ_28_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_27"));

		AddObjective("kill0", "Kill 1 Sequoia", new KillObjective(1, MonsterId.Boss_Sequoia_Q1));

		AddDialogHook("KATYN18_MQ_28_TRACK", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_MQ_28_TRACK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_28_01", "KATYN18_MQ_28", "Accept", "Cancel"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN18_MQ_28_03");
		ZoneServer.Instance.World.FindNPC("KATYN18_MQ_28_TRACK")?.PlayEffectLocal(character.Connection, "mon_foot_smoke_3");
		dialog.HideNPC("KATYN18_MQ_28_TRACK");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

