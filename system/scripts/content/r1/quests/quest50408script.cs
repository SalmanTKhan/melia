//--- Melia Script -----------------------------------------------------------
// The City Under Threat (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Aldoni.
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

[QuestScript(50408)]
public class Quest50408Script : QuestScript
{
	protected override void Load()
	{
		SetId(50408);
		SetName("The City Under Threat (2)");
		SetDescription("Talk to Wizard Aldoni");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_3_SQ_05_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_05"));

		AddObjective("kill0", "Kill All 1 Monsters", new KillObjective(-1, -1));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 41621));

		AddDialogHook("NICO813_SUBQ_NPC1_3", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_NPC1_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO813_SUBQ06_START1", "F_NICOPOLIS_81_3_SQ_06", "Will you be okay?", "Good luck."))
		{
			case 1:
				await dialog.Msg("NICO813_SUBQ06_AGREE1");
				await dialog.Msg("BalloonText/NICO813_SUBQ06_TEXT1/5");
				dialog.HideNPC("NICO813_SUBQ_NPC1_3");
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

		await dialog.Msg("NICO813_SUBQ06_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

