//--- Melia Script -----------------------------------------------------------
// Farewell, My Friend (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Orville.
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

[QuestScript(20343)]
public class Quest20343Script : QuestScript
{
	protected override void Load()
	{
		SetId(20343);
		SetName("Farewell, My Friend (1)");
		SetDescription("Talk to Pilgrim Orville");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIMROAD55_SQ04_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(144));

		AddObjective("kill0", "Kill 1 Glackuman", new KillObjective(1, MonsterId.Boss_Glackuman_Q2));

		AddReward(new ExpReward(1279350, 1279350));
		AddReward(new ItemReward("expCard8", 5));
		AddReward(new ItemReward("Vis", 3744));

		AddDialogHook("PILGRIMROAD55_SQ09", "BeforeStart", BeforeStart);
		AddDialogHook("SQ09_DEAD_PRIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ04_select01", "PILGRIMROAD55_SQ04", "I will find his friend", "Decline"))
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

		// Func/PRIST_DEAD_BODY;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

