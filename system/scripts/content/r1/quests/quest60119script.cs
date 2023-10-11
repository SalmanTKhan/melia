//--- Melia Script -----------------------------------------------------------
// Bishop Urbonas' Whereabouts (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
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

[QuestScript(60119)]
public class Quest60119Script : QuestScript
{
	protected override void Load()
	{
		SetId(60119);
		SetName("Bishop Urbonas' Whereabouts (4)");
		SetDescription("Talk with Priest Pranas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON621_MQ_05_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON621_MQ_03"));

		AddObjective("kill0", "Kill 1 Clymen", new KillObjective(1, MonsterId.Boss_Clymen_Q2));

		AddReward(new ExpReward(40290, 40290));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("PRISON621_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_URBONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON621_MQ_03_02", "PRISON621_MQ_05", "I will check it", "Is there no other way?"))
		{
			case 1:
				await dialog.Msg("PRISON621_MQ_03_02_AG");
				dialog.UnHideNPC("PRISON621_TO_PRISON621_1");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Check the map of the Ashaq Underground Prison 1F in your inventory!", 5);
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

