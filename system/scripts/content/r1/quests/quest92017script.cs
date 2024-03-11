//--- Melia Script -----------------------------------------------------------
// Crossing Over Eternity
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Laima.
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

[QuestScript(92017)]
public class Quest92017Script : QuestScript
{
	protected override void Load()
	{
		SetId(92017);
		SetName("Crossing Over Eternity");
		SetDescription("Talk to Goddess Laima");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP12_2_ENDING_TRACK_03", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ17"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("Premium_RankReset_14d", 1));
		AddReward(new ItemReward("Drug_AddStat", 5));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 132));

		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ17_RAIMA_01", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ18_GIRL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ18_DLG_1", "EP12_2_D_DCAPITAL_108_MQ18", "I will finish my mission", "I'm afraid to finish it"))
		{
			case 1:
				dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ17_RAIMA_01");
				dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ17_RANGDAGIRL_01");
				dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ17_RANGDAMASTER_01");
				dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ17_GILTINE_02");
				dialog.UnHideNPC("EP12_2_D_DCAPITAL_108_MQ18_GIRL_01");
				dialog.UnHideNPC("EP12_2_D_DCAPITAL_108_MQ18_GIRL_02");
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

		await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_22");
		await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_23");
		// Func/SCR_EP12_2_D_DCAPITAL_108_MQ18_AFTERTRACK;
		await dialog.Msg("FadeOutIN/3");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ18_GIRL_01");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ18_GIRL_02");
		dialog.UnHideNPC("NPC_RANGDAGIRL_02");
		dialog.UnHideNPC("NPC_LITTLEGIRL_01");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ16_TRACK_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

