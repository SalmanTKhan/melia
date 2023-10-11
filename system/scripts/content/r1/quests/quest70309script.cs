//--- Melia Script -----------------------------------------------------------
// Strong Survivor [Peltasta Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Peltasta Submaster.
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

[QuestScript(70309)]
public class Quest70309Script : QuestScript
{
	protected override void Load()
	{
		SetId(70309);
		SetName("Strong Survivor [Peltasta Advancement]");
		SetDescription("Talk with Peltasta Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_PELTASTA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PELTASTA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PELTASTA3_1_1", "JOB_2_PELTASTA3", "I am ready to learn", "I'm not ready yet"))
		{
			case 1:
				await dialog.Msg("JOB_2_PELTASTA3_1_2");
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

