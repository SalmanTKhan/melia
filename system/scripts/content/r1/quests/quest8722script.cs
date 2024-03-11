//--- Melia Script -----------------------------------------------------------
// In Search of the Legend [Quarrel Shooter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Go to the Quarrel Shooter Master.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(8722)]
public class Quest8722Script : QuestScript
{
	protected override void Load()
	{
		SetId(8722);
		SetName("In Search of the Legend [Quarrel Shooter Advancement]");
		SetDescription("Go to the Quarrel Shooter Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_QUARREL4_1_01", "JOB_QUARREL4_1", "I'll rub a copy", "Decline"))
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

		await dialog.Msg("JOB_QUARREL4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

