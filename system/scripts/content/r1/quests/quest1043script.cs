//--- Melia Script -----------------------------------------------------------
// Aras' Commission (3)
//--- Description -----------------------------------------------------------
// Quest to Find the Search Scout.
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

[QuestScript(1043)]
public class Quest1043Script : QuestScript
{
	protected override void Load()
	{
		SetId(1043);
		SetName("Aras' Commission (3)");
		SetDescription("Find the Search Scout");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_EAST_REQUEST6_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(7));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_REQUEST2"));

		AddObjective("kill0", "Kill 1 Vubbe Fighter", new KillObjective(1, MonsterId.Boss_Goblin_Warrior));

		AddReward(new ExpReward(6000, 6000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SOLDIER8", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SOLDIER8", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_REQUEST6_dlg1", "SIAUL_EAST_REQUEST6", "Let me defeat the Vubbe Fighter instead of waiting", "I am going to wait for backup"))
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

		//SIAUL_EAST_REQUEST6_FUNC
		await dialog.Msg("SIAUL_EAST_CAMP1_dlg1");
		await dialog.Msg("SIAUL_EAST_REQUEST6_dlg3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

