//--- Melia Script -----------------------------------------------------------
// Deviated Guardian
//--- Description -----------------------------------------------------------
// Quest to Search the deeper part of the Royal Mausoleum.
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

[QuestScript(20186)]
public class Quest20186Script : QuestScript
{
	protected override void Load()
	{
		SetId(20186);
		SetName("Deviated Guardian");
		SetDescription("Search the deeper part of the Royal Mausoleum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA2F_MQ_05_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(86));

		AddObjective("kill0", "Kill 1 Shnayim", new KillObjective(1, MonsterId.Boss_Shnayim_Q1));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("FOOT02_122", 1));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("ZACHA2F_MQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA2F_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_MQ_05_select01", "ZACHA2F_MQ_05", "Defeat Shnayim", "Ignore it"))
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


		return HookResult.Break;
	}
}

