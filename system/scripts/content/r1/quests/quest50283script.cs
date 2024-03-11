//--- Melia Script -----------------------------------------------------------
// Rune Tombstone
//--- Description -----------------------------------------------------------
// Quest to Talk with the Rune Caster Master.
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

[QuestScript(50283)]
public class Quest50283Script : QuestScript
{
	protected override void Load()
	{
		SetId(50283);
		SetName("Rune Tombstone");
		SetDescription("Talk with the Rune Caster Master");

		AddPrerequisite(new LevelPrerequisite(99));

		AddDialogHook("RUNECASTER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("RUNECASTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS38_HQ1_start1", "REMAINS38_HQ1", "I'll get the rubbed copy.", "I'm actually not that curious."))
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

		await dialog.Msg("REMAINS38_HQ1_succ1");
		// Func/REMAINS38_HIDDENQ1_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

