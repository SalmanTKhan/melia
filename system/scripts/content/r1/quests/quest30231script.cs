//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Liepa.
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

[QuestScript(30231)]
public class Quest30231Script : QuestScript
{
	protected override void Load()
	{
		SetId(30231);
		SetName("Inspect Inner Wall District 9 (1)");
		SetDescription("Talk to Kupole Liepa");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_11"));

		AddDialogHook("CASTLE_20_2_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_2_SQ_1_select", "CASTLE_20_2_SQ_1", "Explain what happened on the District 8 and deliever Jore's message.", "It's nothing, really."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_2_SQ_1_agree");
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

		await dialog.Msg("CASTLE_20_2_SQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

