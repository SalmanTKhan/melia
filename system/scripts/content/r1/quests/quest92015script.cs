//--- Melia Script -----------------------------------------------------------
// Demon Goddess Giltine
//--- Description -----------------------------------------------------------
// Quest to Move to Divine Sanctuary..
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

[QuestScript(92015)]
public class Quest92015Script : QuestScript
{
	protected override void Load()
	{
		SetId(92015);
		SetName("Demon Goddess Giltine");
		SetDescription("Move to Divine Sanctuary.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_ENDING_TRACK_01", "m_boss_scenario");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ15"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("WARP_D_DCAPITAL_108_TO_DEVINE_SANCTUARY", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ16_SEL_01", "EP12_2_D_DCAPITAL_108_MQ16", "Proceed with the quest.", "Move without proceeding the quest."))
		{
			case 1:
				dialog.UnHideNPC("EP12_2_D_DCAPITAL_108_MQ16_TRACK_01");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

