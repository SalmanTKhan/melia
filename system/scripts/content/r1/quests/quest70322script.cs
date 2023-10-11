//--- Melia Script -----------------------------------------------------------
// Raw Power Only [Barbarian Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Barbarian Submaster.
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

[QuestScript(70322)]
public class Quest70322Script : QuestScript
{
	protected override void Load()
	{
		SetId(70322);
		SetName("Raw Power Only [Barbarian Advancement]");
		SetDescription("Talk with Barbarian Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_BARBARIAN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_BARBARIAN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_BARABARIAN4_1_1", "JOB_2_BARBARIAN4", "Give me some lessons", "I've learned enough"))
		{
			case 1:
				await dialog.Msg("JOB_2_BARABARIAN4_1_2");
				character.Quests.Start(this.QuestId);
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

