//--- Melia Script -----------------------------------------------------------
// What was in the storage device (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Aldoni.
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

[QuestScript(50400)]
public class Quest50400Script : QuestScript
{
	protected override void Load()
	{
		SetId(50400);
		SetName("What was in the storage device (2)");
		SetDescription("Talk to Wizard Aldoni");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_3_SQ_02_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_01"));

		AddDialogHook("NICO813_SUBQ_NPC1_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_NPC1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO813_SUBQ02_START1", "F_NICOPOLIS_81_3_SQ_02", "Let's go together and check.", "I'll go check later."))
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

		await dialog.Msg("NICO813_SUBQ03_SUCC1");
		dialog.HideNPC("NICO813_SUBQ_NPC1_2");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("NICO813_SUBQ_NPC1_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

