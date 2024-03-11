//--- Melia Script -----------------------------------------------------------
// Beholder's Purpose
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Lada.
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

[QuestScript(91046)]
public class Quest91046Script : QuestScript
{
	protected override void Load()
	{
		SetId(91046);
		SetName("Beholder's Purpose");
		SetDescription("Talk to Goddess Lada");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_2_MQ_08_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_07"));

		AddObjective("kill0", "Kill 1 Darbas Smasher", new KillObjective(1, MonsterId.Boss_Darbas_Smasher));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_08_DLG1", "EP13_F_SIAULIAI_2_MQ_08", "Enemy can be damaged by destroying the Mirtinas Storage", "I'll rearrange first"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP13_F_SIAULIAI_2_MQ_LADA_3");
				dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_08_TRACK_1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

