//--- Melia Script -----------------------------------------------------------
// Ardor for Study (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Friedka.
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

[QuestScript(20147)]
public class Quest20147Script : QuestScript
{
	protected override void Load()
	{
		SetId(20147);
		SetName("Ardor for Study (2)");
		SetDescription("Talk to Archaeologist Friedka");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS28_MQ5_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("ROKAS28_EXPOSURE"));

		AddObjective("kill0", "Kill 1 Bebraspion", new KillObjective(1, MonsterId.Boss_Bebraspion_Q1));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_FRIDKA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_FRIDKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS28_MQ5_select1", "ROKAS28_MQ5", "I'll rub a copy", "I can only help so much"))
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

		await dialog.Msg("ROKAS28_MQ5_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

