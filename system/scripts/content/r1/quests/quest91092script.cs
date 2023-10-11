//--- Melia Script -----------------------------------------------------------
// Temporary Base
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(91092)]
public class Quest91092Script : QuestScript
{
	protected override void Load()
	{
		SetId(91092);
		SetName("Temporary Base");
		SetDescription("Talk to the Centurion Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE2_MQ_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(462));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE1_MQ_7"));

		AddObjective("kill0", "Kill 12 Blickferret Fighter(s) or Blickferret Swordsman(s)", new KillObjective(12, 59695, 59696));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));

		AddDialogHook("EP14_1_F_CASTLE_1_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE2_MQ_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE2_MQ_1_SNPC_DLG1", "EP14_1_FCASTLE2_MQ_1", "Let's go to the Delmore Manor", "I still have other things to do"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				// Func/SCR_EP14_1_F_CASTLE_2_KRAJICEK_SUMMON;
				dialog.HideNPC("EP14_1_F_CASTLE_1_NPC3");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("EP14_1_FCASTLE2_MQ_1_CNPC_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

