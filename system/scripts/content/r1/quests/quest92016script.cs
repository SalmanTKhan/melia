//--- Melia Script -----------------------------------------------------------
// Destiny of the Goddess
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Laima.
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

[QuestScript(92016)]
public class Quest92016Script : QuestScript
{
	protected override void Load()
	{
		SetId(92016);
		SetName("Destiny of the Goddess");
		SetDescription("Talk to Goddess Laima");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_ENDING_TRACK_02", "m_boss_scenario");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ16"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ17_RAIMA_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ17_DLG_4", "EP12_2_D_DCAPITAL_108_MQ17", "Alright", "The time has not arrived yet."))
		{
			case 1:
				await dialog.Msg("BalloonText/EP12_2_D_DCAPITAL_108_MQ17_DLG_5/3");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

