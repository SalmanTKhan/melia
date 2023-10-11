//--- Melia Script -----------------------------------------------------------
// Not as Intended (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Supply Officer.
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

[QuestScript(1037)]
public class Quest1037Script : QuestScript
{
	protected override void Load()
	{
		SetId(1037);
		SetName("Not as Intended (4)");
		SetDescription("Talk to the Supply Officer");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_EAST_RECLAIM7_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(7));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_RECLAIM6"));

		AddObjective("kill0", "Kill 5 Weaver(s)", new KillObjective(5, MonsterId.Weaver));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_RECLAIM7_dlg1", "SIAUL_EAST_RECLAIM7", "I'll defeat the Weavers", "Cancel"))
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

		await dialog.Msg("SIAUL_EAST_RECLAIM7_dlg3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

