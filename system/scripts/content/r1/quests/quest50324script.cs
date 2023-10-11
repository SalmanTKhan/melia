//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (10)
//--- Description -----------------------------------------------------------
// Quest to Listen to the song with Indrea.
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

[QuestScript(50324)]
public class Quest50324Script : QuestScript
{
	protected override void Load()
	{
		SetId(50324);
		SetName("I Can Hear You Singing (10)");
		SetDescription("Listen to the song with Indrea");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_1_SQ9_TRACK", "track");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ9_1"));

		AddObjective("kill0", "Kill 1 Rocktortuga", new KillObjective(1, MonsterId.Boss_Rocktortuga_Q3));

		AddReward(new ExpReward(131897408, 131897408));
		AddReward(new ItemReward("Vis", 16512));
		AddReward(new ItemReward("expCard15", 2));

		AddDialogHook("WTREES221_SUBQ_NPC5", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ9_START1", "WTREES22_1_SQ9", "Let's listen to the song.", "Have fun listening."))
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

		// Func/SCR_WTREES22_1_SUBQ9_COMP;
		dialog.HideNPC("WTREES221_SUBQ_NPC5");
		dialog.UnHideNPC("WTREES221_SUBQ_NPC6");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

