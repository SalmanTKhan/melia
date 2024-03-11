//--- Melia Script -----------------------------------------------------------
// An Endless Mission (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Alan.
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

[QuestScript(4394)]
public class Quest4394Script : QuestScript
{
	protected override void Load()
	{
		SetId(4394);
		SetName("An Endless Mission (1)");
		SetDescription("Talk to Soldier Alan");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN23_Q_4_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(123));

		AddObjective("kill0", "Kill 1 Rajapearl", new KillObjective(1, MonsterId.Boss_Rajapearl));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_ALAN", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_ALAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN23_Q_4_select1", "THORN23_Q_4", "Weird, but I'll go instead", "I'm not a new recruit"))
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

		await dialog.Msg("THORN23_Q_4_prog1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

