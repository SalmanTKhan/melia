//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Oscaras.
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

[QuestScript(50210)]
public class Quest50210Script : QuestScript
{
	protected override void Load()
	{
		SetId(50210);
		SetName("Danger the Lurks in the Forest (1)");
		SetDescription("Talk with Oscaras");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN43_2_SQ9_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(310));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ8"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 128340));

		AddDialogHook("BRACKEN432_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN432_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_2_SQ9_START1", "BRACKEN43_2_SQ9", "Deliver the Cure to Oscaras.", "The cure isn't ready yet."))
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

		await dialog.Msg("BRACKEN43_2_SQ9_SUCC1");
		dialog.HideNPC("BRACKEN432_SUBQ_NPC2");
		// Func/BRACKEN432_SUBQ9_COMPLET;
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("BRACKEN432_SUBQ_NPC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

