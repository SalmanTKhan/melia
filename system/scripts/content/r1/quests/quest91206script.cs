//--- Melia Script -----------------------------------------------------------
// To the Pied Piper Master
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Ausrine.
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

[QuestScript(91206)]
public class Quest91206Script : QuestScript
{
	protected override void Load()
	{
		SetId(91206);
		SetName("To the Pied Piper Master");
		SetDescription("Talk to Goddess Ausrine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_2_MQ_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(493));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_2_MQ_1"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("EP15_2_D_NICOPOLIS_2_MQ_2_ITEM_01", 1));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICO_2_AUSIRINE_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_2_D_NICOPOLIS_2_MQ_2_PIP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_2_D_NICOPOLIS_2_MQ_2_DLG1", "EP15_2_D_NICOPOLIS_2_MQ_2", "Alright", "I'm going to do something else for a while."))
		{
			case 1:
				// Func/SCR_EP15_2_D_NICO_2_AUSIRINE_1_AFTER;
				dialog.UnHideNPC("EP15_2_D_NICOPOLIS_2_MQ_2_PIP");
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

		await dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_2_DLG4");
		await dialog.Msg("FadeOutIN/2000");
		dialog.HideNPC("EP15_2_D_NICOPOLIS_2_MQ_2_PIP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

