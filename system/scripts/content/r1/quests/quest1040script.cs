//--- Melia Script -----------------------------------------------------------
// Aras' Commission (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Aras.
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

[QuestScript(1040)]
public class Quest1040Script : QuestScript
{
	protected override void Load()
	{
		SetId(1040);
		SetName("Aras' Commission (3)");
		SetDescription("Talk to Aras");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_EAST_REQUEST3_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 4 Pokubu(s) or Vubbe Miner(s)", new KillObjective(4, 401341, 11125));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));

		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_REQUEST3_dlg1", "SIAUL_EAST_REQUEST3", "I'll find the traces of the Vubbe Fighter", "Cancel"))
		{
			case 1:
				await dialog.Msg("SIAUL_EAST_REQUEST3_dlg1_a");
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

		await dialog.Msg("SIAUL_EAST_REQUEST3_dlg3");
		dialog.UnHideNPC("SIAUL_EAST_SOLDIER8");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

