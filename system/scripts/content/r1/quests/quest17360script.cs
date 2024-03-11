//--- Melia Script -----------------------------------------------------------
// Eternal Worship [Krivis Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Meet with the Cleric Master.
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

[QuestScript(17360)]
public class Quest17360Script : QuestScript
{
	protected override void Load()
	{
		SetId(17360);
		SetName("Eternal Worship [Krivis Advancement] (3)");
		SetDescription("Meet with the Cleric Master");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_KRIVI4_2"));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_KRIVI4_3_ST", "JOB_KRIVI4_3", "I'll leave for Fedimian", "I will just stay a while"))
		{
			case 1:
				await dialog.Msg("JOB_KRIVI4_3_ST_AC");
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

		await dialog.Msg("JOB_KRIVI4_3_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

