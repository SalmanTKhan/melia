//--- Melia Script -----------------------------------------------------------
// Collecting the Sacred Object (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Merrisa.
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

[QuestScript(41670)]
public class Quest41670Script : QuestScript
{
	protected override void Load()
	{
		SetId(41670);
		SetName("Collecting the Sacred Object (4)");
		SetDescription("Talk to Merrisa");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("PILGRIM_48_JURATE", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_JURATE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_48_SQ_070_ST", "PILGRIM_48_SQ_070", "I will go excavate it", "Cancel"))
		{
			case 1:
				await dialog.Msg("PILGRIM_48_SQ_070_AC");
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

		await dialog.Msg("PILGRIM_48_SQ_070_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

