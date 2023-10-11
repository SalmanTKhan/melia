//--- Melia Script -----------------------------------------------------------
// Camp Crisis
//--- Description -----------------------------------------------------------
// Quest to Go to the Eastern Woods Base Camp.
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

[QuestScript(1031)]
public class Quest1031Script : QuestScript
{
	protected override void Load()
	{
		SetId(1031);
		SetName("Camp Crisis");
		SetDescription("Go to the Eastern Woods Base Camp");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_EAST_CAMP4_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(7));

		AddObjective("kill0", "Kill 1 Poata", new KillObjective(1, MonsterId.Boss_Poata));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_CAMP4_ST", "SIAUL_EAST_CAMP4", "I didn't see anything like that", "Not really my problem"))
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

		await dialog.Msg("SIAUL_EAST_CAMP4_dlg2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

