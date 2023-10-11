//--- Melia Script -----------------------------------------------------------
// Big Catch [Squire Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Squire Master.
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

[QuestScript(8726)]
public class Quest8726Script : QuestScript
{
	protected override void Load()
	{
		SetId(8726);
		SetName("Big Catch [Squire Advancement]");
		SetDescription("Meet the Squire Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SQUIRE4_1_01", "JOB_SQUIRE4_1", "I'll be back after practice", "I'll wait a little bit"))
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

		await dialog.Msg("JOB_SQUIRE4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

