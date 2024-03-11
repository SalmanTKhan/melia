//--- Melia Script -----------------------------------------------------------
// Threats of the Eastern Woods
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Aras to inquire about the Miners' Village.
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

[QuestScript(1032)]
public class Quest1032Script : QuestScript
{
	protected override void Load()
	{
		SetId(1032);
		SetName("Threats of the Eastern Woods");
		SetDescription("Talk to Knight Aras to inquire about the Miners' Village");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_EAST_RECLAIM1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(7));
		AddPrerequisite(new CompletedPrerequisite("EAST_PREPARE_1"));

		AddObjective("kill0", "Kill 4 Pokubu(s)", new KillObjective(4, MonsterId.Pokubu));

		AddReward(new ExpReward(3000, 3000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_RECLAIM1_dlg1", "SIAUL_EAST_RECLAIM1", "I will accept your suggestion", "I will wait until the problem is solved"))
		{
			case 1:
				await dialog.Msg("SIAUL_EAST_RECLAIM1_dlg1_a");
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

		await dialog.Msg("SIAUL_EAST_RECLAIM1_dlg3");
		dialog.UnHideNPC("SIAUL_EAST_SOLDIER6");
		dialog.UnHideNPC("SIAUL_EAST_SOLDIER7");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

