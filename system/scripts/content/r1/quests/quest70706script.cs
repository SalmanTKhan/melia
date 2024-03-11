//--- Melia Script -----------------------------------------------------------
// The Whereabouts of the Key
//--- Description -----------------------------------------------------------
// Quest to Talk to the soul of Victoras.
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

[QuestScript(70706)]
public class Quest70706Script : QuestScript
{
	protected override void Load()
	{
		SetId(70706);
		SetName("The Whereabouts of the Key");
		SetDescription("Talk to the soul of Victoras");

		AddPrerequisite(new LevelPrerequisite(278));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ06"));

		AddDialogHook("BRACKEN421_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN421_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN421_SQ_07_start", "BRACKEN42_1_SQ07", "Of course, I will open it myself.", "Check the contents later."))
		{
			case 1:
				await dialog.Msg("BRACKEN421_SQ_07_agree");
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

		if (character.Inventory.HasItem("BRACKEN42_1_SQ07_ITEM", 1))
		{
			character.Inventory.RemoveItem("BRACKEN42_1_SQ07_ITEM", 1);
			await dialog.Msg("BRACKEN421_SQ_07_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

