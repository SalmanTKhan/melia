//--- Melia Script -----------------------------------------------------------
// Laima and Triple-Layered Wall
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Jore.
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

[QuestScript(30219)]
public class Quest30219Script : QuestScript
{
	protected override void Load()
	{
		SetId(30219);
		SetName("Laima and Triple-Layered Wall");
		SetDescription("Talk to Kupole Jore");

		AddPrerequisite(new LevelPrerequisite(279));

		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_3_SQ_1_select", "CASTLE_20_3_SQ_1", "What are you doing here?", "None of my business, it seems like."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_3_SQ_1_agree");
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

		await dialog.Msg("CASTLE_20_3_SQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

