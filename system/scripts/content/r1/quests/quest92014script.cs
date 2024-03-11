//--- Melia Script -----------------------------------------------------------
// The Last Protective Device (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rangda Master.
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

[QuestScript(92014)]
public class Quest92014Script : QuestScript
{
	protected override void Load()
	{
		SetId(92014);
		SetName("The Last Protective Device (5)");
		SetDescription("Talk to the Rangda Master");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP12_2_D_DCAPITAL_108_MQ15_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ14"));

		AddObjective("kill0", "Kill 1 Raganosis Commander", new KillObjective(1, MonsterId.Boss_RaganosisCommander));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ01_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ15_DLG1", "EP12_2_D_DCAPITAL_108_MQ15", "Encourage Mulia.", "I need more rest."))
		{
			case 1:
				dialog.UnHideNPC("EP12_2_D_DCAPITAL_108_MQ01_MASTER");
				dialog.UnHideNPC("EP12_2_D_DCAPITAL_108_MQ15_GIRL");
				// Func/RANGDAGIRL108_SUMMON_CANCEL;
				// Func/RANGDAMASTER108_SUMMON_CANCEL;
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

		await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ15_DLG2");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

