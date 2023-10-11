//--- Melia Script -----------------------------------------------------------
// The Best Offense is a Good Defense [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Submaster.
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

[QuestScript(1154)]
public class Quest1154Script : QuestScript
{
	protected override void Load()
	{
		SetId(1154);
		SetName("The Best Offense is a Good Defense [Rodelero Advancement]");
		SetDescription("Talk to the Rodelero Submaster");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RODELERO3_1_select1", "JOB_RODELERO3_1", "I'll bring the upgraded shield.", "I will come back later"))
		{
			case 1:
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

		await dialog.Msg("JOB_RODELERO3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

