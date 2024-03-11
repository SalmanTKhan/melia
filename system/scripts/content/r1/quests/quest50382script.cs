//--- Melia Script -----------------------------------------------------------
// Remnants of the Past
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
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

[QuestScript(50382)]
public class Quest50382Script : QuestScript
{
	protected override void Load()
	{
		SetId(50382);
		SetName("Remnants of the Past");
		SetDescription("Talk to Owynia Dilben");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_1_SQ_04_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_03"));

		AddObjective("kill0", "Kill 1 Pervading Queen", new KillObjective(1, MonsterId.Boss_PervadingQueen));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 2));
		AddReward(new ItemReward("Vis", 33316));

		AddDialogHook("NICO811_NPC1_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO811_SUBQ4_START1", "F_NICOPOLIS_81_1_SQ_04", "I'll go investigate.", "Leave this place"))
		{
			case 1:
				await dialog.Msg("NICO811_SUBQ4_AGREE1");
				dialog.HideNPC("NICO811_NPC1_2");
				await dialog.Msg("FadeOutIN/1000");
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

		await dialog.Msg("NICO811_SUBQ4_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

