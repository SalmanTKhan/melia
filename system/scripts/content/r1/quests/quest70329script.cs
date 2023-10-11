//--- Melia Script -----------------------------------------------------------
// Borrowing Abilities [Sadhu Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sadhu Master.
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

[QuestScript(70329)]
public class Quest70329Script : QuestScript
{
	protected override void Load()
	{
		SetId(70329);
		SetName("Borrowing Abilities [Sadhu Advancement]");
		SetDescription("Talk to the Sadhu Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_SADHU_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SADHU_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SADHU4_1_1", "JOB_2_SADHU4", "I will take the test", "I'll go and look for it"))
		{
			case 1:
				await dialog.Msg("JOB_2_SADHU4_1_2");
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

