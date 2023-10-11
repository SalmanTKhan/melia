//--- Melia Script -----------------------------------------------------------
// Creating Distractions (5)
//--- Description -----------------------------------------------------------
// Quest to Go find a place to hide.
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

[QuestScript(50332)]
public class Quest50332Script : QuestScript
{
	protected override void Load()
	{
		SetId(50332);
		SetName("Creating Distractions (5)");
		SetDescription("Go find a place to hide");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_2_SQ7_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(348));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_2_SQ6"));

		AddObjective("kill0", "Kill 1 Mummyghast", new KillObjective(1, MonsterId.Boss_Mummyghast_Q2));

		AddReward(new ExpReward(131897408, 131897408));
		AddReward(new ItemReward("Vis", 16704));
		AddReward(new ItemReward("expCard15", 2));

		AddDialogHook("WTREES22_2_SUBQ6_IN", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_2_SQ7_START1", "WTREES22_2_SQ7", "Hide.", "The situation seems fine so far."))
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WTREES22_2_SQ8");
	}
}

