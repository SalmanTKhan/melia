//--- Melia Script -----------------------------------------------------------
// The Birth Process of a Comrade [Peltasta Advancement]
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

[QuestScript(70303)]
public class Quest70303Script : QuestScript
{
	protected override void Load()
	{
		SetId(70303);
		SetName("The Birth Process of a Comrade [Peltasta Advancement]");
		SetDescription("Talk with Peltasta Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 10 Pokuborn Tusk(s)", new CollectItemObjective("JOB_2_PELTASTA2_ITEM2", 10));
		AddDrop("JOB_2_PELTASTA2_ITEM2", 8f, "Sec_arburn_pokubu");

		AddDialogHook("JOB_2_PELTASTA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PELTASTA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PELTASTA2_1_1", "JOB_2_PELTASTA2", "I will take the test", "I'll think about it again"))
		{
			case 1:
				await dialog.Msg("JOB_2_PELTASTA2_1_2");
				dialog.UnHideNPC("JOB_2_PELTASTA2_WOOD");
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

