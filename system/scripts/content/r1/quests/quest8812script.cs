//--- Melia Script -----------------------------------------------------------
// White Lie (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Benjaminas.
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

[QuestScript(8812)]
public class Quest8812Script : QuestScript
{
	protected override void Load()
	{
		SetId(8812);
		SetName("White Lie (3)");
		SetDescription("Talk to Grave Robber Benjaminas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH59_SQ_13_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(184));
		AddPrerequisite(new CompletedPrerequisite("FLASH59_SQ_12"));

		AddObjective("kill0", "Kill 1 Saltistter", new KillObjective(1, MonsterId.Boss_Saltistter_Q1));

		AddReward(new ExpReward(1884006, 1884006));
		AddReward(new ItemReward("expCard9", 5));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_BENJAMINAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_BENJAMINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_13_01", "FLASH59_SQ_13", "Wish you luck", "Tell him that it's not the time"))
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

		await dialog.Msg("FLASH59_SQ_13_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

