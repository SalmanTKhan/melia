//--- Melia Script -----------------------------------------------------------
// Avoiding Infatuation (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Witas.
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

[QuestScript(19910)]
public class Quest19910Script : QuestScript
{
	protected override void Load()
	{
		SetId(19910);
		SetName("Avoiding Infatuation (4)");
		SetDescription("Talk to Pilgrim Witas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM52_SQ_050_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(133));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_040"));

		AddObjective("kill0", "Kill 1 King Liverwort", new KillObjective(1, MonsterId.Boss_Hepatica_King_Q1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_NPC02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_NPC02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM52_SQ_050_ST", "PILGRIM52_SQ_050", "Give the portrait and handkerchief", "It's frightening. Make a run for it!"))
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

		await dialog.Msg("PILGRIM52_SQ_050_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

