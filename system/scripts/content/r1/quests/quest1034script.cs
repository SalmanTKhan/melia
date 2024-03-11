//--- Melia Script -----------------------------------------------------------
// Sentinel's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Listen to the Sentinel about the Supplies Camp.
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

[QuestScript(1034)]
public class Quest1034Script : QuestScript
{
	protected override void Load()
	{
		SetId(1034);
		SetName("Sentinel's Favor (2)");
		SetDescription("Listen to the Sentinel about the Supplies Camp");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_EAST_RECLAIM3_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(7));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_RECLAIM2"));

		AddObjective("kill0", "Kill 10 Chupacabra(s) or Yellow Chupacabra(s)", new KillObjective(10, 400961, 400965));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SOLDIER9", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SOLDIER9", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_RECLAIM3_dlg1", "SIAUL_EAST_RECLAIM3", "I'll get the Supplies Camp back", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAUL_EAST_RECLAIM3_dlg1_a");
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

		await dialog.Msg("SIAUL_EAST_RECLAIM3_dlg3");
		dialog.UnHideNPC("SIAUL_EAST_SUPPLY_MANAGER");
		dialog.UnHideNPC("SIAUL_EAST_SOLDIER4");
		dialog.UnHideNPC("SIAUL_EAST_SOLDIER5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

