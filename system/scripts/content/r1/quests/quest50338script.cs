//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50338)]
public class Quest50338Script : QuestScript
{
	protected override void Load()
	{
		SetId(50338);
		SetName("Narvas Temple's Barrier (4)");
		SetDescription("Talk to Monk Aistis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_3_SQ4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(351));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_3_SQ3"));

		AddObjective("kill0", "Kill 10 Black Hohen Gulak(s) or Black Hohen Ritter(s) or Black Hohen Mane(s) or Black Hohen Barkle(s)", new KillObjective(10, 58851, 58846, 58852, 58845));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 17901));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_3_SUBQ1_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_3_SUBQ1_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_3_SUBQ4_START1", "WTREES22_3_SQ4", "I'll deal with the demons. You go gather the components.", "It looks too dangerous."))
		{
			case 1:
				await dialog.Msg("WTREES22_3_SUBQ4_AGG1");
				dialog.HideNPC("WTREES22_3_SUBQ1_NPC3");
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

		await dialog.Msg("WTREES22_3_SUBQ4_SUCC1");
		dialog.HideNPC("WTREES22_3_SUBQ1_NPC4");
		dialog.UnHideNPC("WTREES22_3_SUBQ1_NPC3");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

