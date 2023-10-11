//--- Melia Script -----------------------------------------------------------
// Tools and Creations [Dievdirbys Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Dievdirbys Submaster.
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

[QuestScript(70316)]
public class Quest70316Script : QuestScript
{
	protected override void Load()
	{
		SetId(70316);
		SetName("Tools and Creations [Dievdirbys Advancement] (1)");
		SetDescription("Talk with Dievdirbys Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_BLACKSMITH", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_DIEVDIRBYS3_1_1", "JOB_2_DIEVDIRBYS3_1", "What is the task?", "I don't think I can tend to such a puny request"))
		{
			case 1:
				await dialog.Msg("JOB_2_DIEVDIRBYS3_1_2");
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

