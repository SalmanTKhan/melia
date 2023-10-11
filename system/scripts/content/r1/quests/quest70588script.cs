//--- Melia Script -----------------------------------------------------------
// Rescuing The Captured Stella
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Mattas.
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

[QuestScript(70588)]
public class Quest70588Script : QuestScript
{
	protected override void Load()
	{
		SetId(70588);
		SetName("Rescuing The Captured Stella");
		SetDescription("Talk to Monk Mattas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM41_5_SQ09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(271));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ08"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_09", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM415_SQ_09_start", "PILGRIM41_5_SQ09", "Leave it to me", "Say that it won't be a problem because she's a hostage"))
		{
			case 1:
				await dialog.Msg("PILGRIM415_SQ_09_agree");
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

		await dialog.Msg("FadeOutIN/1000");
		await dialog.Msg("NPCAin/PILGRIM415_SQ_09/std/1");
		await dialog.Msg("PILGRIM415_SQ_09_succ");
		dialog.HideNPC("PILGRIM415_SQ_09");
		dialog.UnHideNPC("PILGRIM415_SQ_10");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

