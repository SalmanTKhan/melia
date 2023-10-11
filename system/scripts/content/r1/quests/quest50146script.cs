//--- Melia Script -----------------------------------------------------------
// Welcomed One (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Guylens.
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

[QuestScript(50146)]
public class Quest50146Script : QuestScript
{
	protected override void Load()
	{
		SetId(50146);
		SetName("Welcomed One (1)");
		SetDescription("Talk to Soldier Guylens");

		AddPrerequisite(new LevelPrerequisite(238));

		AddDialogHook("TABLE70_SOLDIER1_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ1_startnpc01", "TABLELAND_70_SQ1", "I'll go see Assistant Commander Talon.", "I'm sorry, but I don't think I can"))
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

		await dialog.Msg("TABLELAND_70_SQ1_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

