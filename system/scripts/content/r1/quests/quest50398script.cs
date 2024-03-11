//--- Melia Script -----------------------------------------------------------
// The Closing Dragnet (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Auguste Dupin.
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

[QuestScript(50398)]
public class Quest50398Script : QuestScript
{
	protected override void Load()
	{
		SetId(50398);
		SetName("The Closing Dragnet (5)");
		SetDescription("Talk to Auguste Dupin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_2_SQ_06_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(384));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_11"));

		AddObjective("kill0", "Kill 1 Teal Specter", new KillObjective(1, MonsterId.Boss_TealSpecter));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 2));
		AddReward(new ItemReward("Vis", 31000));

		AddDialogHook("NICO812_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICOPOLIS812_SQ12_START1", "F_NICOPOLIS_81_2_SQ_12", "Follow Dupin.", "It looks dangerous"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("NICO812_SUBQ_NPC2");
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

		await dialog.Msg("NICOPOLIS812_SQ12_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

