//--- Melia Script -----------------------------------------------------------
// Timing Attacks [Fencer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Fencer Master.
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

[QuestScript(30122)]
public class Quest30122Script : QuestScript
{
	protected override void Load()
	{
		SetId(30122);
		SetName("Timing Attacks [Fencer Advancement]");
		SetDescription("Talk with the Fencer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_FENCER_7_1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("MASTER_FENCER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FENCER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FENCER_7_1_select", "JOB_FENCER_7_1", "Tell him that it won't be a problem", "I will get it again later"))
		{
			case 1:
				await dialog.Msg("JOB_FENCER_7_1_agree");
				dialog.UnHideNPC("JOB_FENCER_7_1_WOOD_CARVING");
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

		await dialog.Msg("JOB_FENCER_7_1_succ");
		dialog.HideNPC("JOB_FENCER_7_1_WOOD_CARVING");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

