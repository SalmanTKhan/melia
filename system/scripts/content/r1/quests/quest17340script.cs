//--- Melia Script -----------------------------------------------------------
// Eternal Worship [Krivis Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Meet the Krivis Master.
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

[QuestScript(17340)]
public class Quest17340Script : QuestScript
{
	protected override void Load()
	{
		SetId(17340);
		SetName("Eternal Worship [Krivis Advancement] (1)");
		SetDescription("Meet the Krivis Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_KRIVI4_1_ST", "JOB_KRIVI4_1", "I'll go on a pilgrimage", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_KRIVI4_1_AC");
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

		await dialog.Msg("JOB_KRIVI4_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_KRIVI4_2");
	}
}

