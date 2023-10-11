//--- Melia Script -----------------------------------------------------------
// The Closing Dragnet (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Auguste Dupin.
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

[QuestScript(50394)]
public class Quest50394Script : QuestScript
{
	protected override void Load()
	{
		SetId(50394);
		SetName("The Closing Dragnet (1)");
		SetDescription("Talk to Auguste Dupin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_2_SQ_02_5_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(384));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_07"));

		AddObjective("kill0", "Kill 6 Vine Walker(s) or Wiza Moya(s)", new KillObjective(6, 59148, 59150));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 29000));

		AddDialogHook("NICO812_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICOPOLIS812_SQ08_START1", "F_NICOPOLIS_81_2_SQ_08", "I'll go with you.", "... Bye now."))
		{
			case 1:
				dialog.HideNPC("NICO812_SUBQ_NPC1");
				await dialog.Msg("FadeOutIN/1000");
				dialog.UnHideNPC("NICO812_SUBQ_NPC2");
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

		await dialog.Msg("NICOPOLIS812_SQ08_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

