//--- Melia Script -----------------------------------------------------------
// Without Comrades Sometimes [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Master.
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

[QuestScript(70333)]
public class Quest70333Script : QuestScript
{
	protected override void Load()
	{
		SetId(70333);
		SetName("Without Comrades Sometimes [Rodelero Advancement]");
		SetDescription("Talk to the Rodelero Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_RODELERO5_1_1", "JOB_2_RODELERO5", "If that's the way to become stronger, I will follow", "I don't understand why you are giving up on your strength"))
		{
			case 1:
				await dialog.Msg("JOB_2_RODELERO5_1_2");
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

