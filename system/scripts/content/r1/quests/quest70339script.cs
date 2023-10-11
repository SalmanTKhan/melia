//--- Melia Script -----------------------------------------------------------
// Overcoming Difficulties [Paladin Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet with the Paladin Submaster.
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

[QuestScript(70339)]
public class Quest70339Script : QuestScript
{
	protected override void Load()
	{
		SetId(70339);
		SetName("Overcoming Difficulties [Paladin Advancement]");
		SetDescription("Meet with the Paladin Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_2_PALADIN5_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 8 Kepari(s) or Red Wood Goblin(s)", new KillObjective(8, 41449, 41291));

		AddDialogHook("JOB_2_PALADIN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PALADIN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PALADIN5_1_1", "JOB_2_PALADIN5", "I am ready", "I need more time to think"))
		{
			case 1:
				await dialog.Msg("JOB_2_PALADIN5_1_2");
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
}

