//--- Melia Script -----------------------------------------------------------
// Sculptor Hilda's Data (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Hilda.
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

[QuestScript(20162)]
public class Quest20162Script : QuestScript
{
	protected override void Load()
	{
		SetId(20162);
		SetName("Sculptor Hilda's Data (2)");
		SetDescription("Talk to Sculptor Hilda");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS25_SQ_07_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_SQ_06"));

		AddDialogHook("ROKAS25_HILDA2", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_HILDA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_SQ_07_select_01", "ROKAS25_SQ_07", "I can protect you", "I'm busy"))
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

		await dialog.Msg("ROKAS25_SQ_07_success_01");
		ZoneServer.Instance.World.FindNPC("ROKAS25_HILDA2")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("ROKAS25_HILDA2");
		dialog.UnHideNPC("ROKAS25_HILDA3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

