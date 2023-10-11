//--- Melia Script -----------------------------------------------------------
// Interview - Necromancer Master
//--- Description -----------------------------------------------------------
// Quest to Deliver the Letter to the Necromancer Master.
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

[QuestScript(90169)]
public class Quest90169Script : QuestScript
{
	protected override void Load()
	{
		SetId(90169);
		SetName("Interview - Necromancer Master");
		SetDescription("Deliver the Letter to the Necromancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LOWLV_MASTER_SQ_50_TRACK_RE", "None");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_MASTER_ENCY_SQ_10"));
		AddPrerequisite(new ItemPrerequisite("LOWLV_MASTER_ENCY_SQ_10_ITEM2", -100));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("LOWLV_MASTER_ENCY_SQ_50_ITEM", 1));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_NECRO4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_NECRO4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_MASTER_ENCY_SQ_50_ST", "LOWLV_MASTER_ENCY_SQ_50", "Alright, I'll help you", "I have more urgent issues to tend to"))
		{
			case 1:
				await dialog.Msg("LOWLV_MASTER_ENCY_SQ_50_AG");
				dialog.UnHideNPC("LOWLV_MASTER_ENCY_SQ_50_DOLL");
				dialog.UnHideNPC("LOWLV_MASTER_ENCY_SQ_50");
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

		await dialog.Msg("LOWLV_MASTER_ENCY_SQ_50_SU");
		dialog.HideNPC("LOWLV_MASTER_ENCY_SQ_50");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

