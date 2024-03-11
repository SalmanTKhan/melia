//--- Melia Script -----------------------------------------------------------
// To each his own
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70605)]
public class Quest70605Script : QuestScript
{
	protected override void Load()
	{
		SetId(70605);
		SetName("To each his own");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(274));
		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ05"));

		AddDialogHook("ABBEY416_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY416_SQ_06_start", "ABBEY41_6_SQ06", "Say that it isn't too difficult", "Say that going together really seems like the better idea"))
		{
			case 1:
				await dialog.Msg("ABBEY416_SQ_06_agree");
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

		if (character.Inventory.HasItem("ABBEY41_6_SQ06_ITEM", 1))
		{
			character.Inventory.RemoveItem("ABBEY41_6_SQ06_ITEM", 1);
			await dialog.Msg("ABBEY416_SQ_06_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

