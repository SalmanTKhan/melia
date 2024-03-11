//--- Melia Script -----------------------------------------------------------
// The Lost Object
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elder's Granddaughter.
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

[QuestScript(50273)]
public class Quest50273Script : QuestScript
{
	protected override void Load()
	{
		SetId(50273);
		SetName("The Lost Object");
		SetDescription("Talk to the Elder's Granddaughter");

		AddPrerequisite(new LevelPrerequisite(65));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("3CMLAKE_83_LADY", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_LADY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F3CMLAKE83_HQ1_start1", "F3CMLAKE83_HQ1", "I'll try", "I'll find it myself"))
		{
			case 1:
				dialog.UnHideNPC("F3CMLAKE83_HIDDEN_OBJ1");
				dialog.UnHideNPC("F3CMLAKE83_HIDDEN_OBJ2");
				dialog.UnHideNPC("F3CMLAKE83_HIDDEN_OBJ3");
				dialog.UnHideNPC("F3CMLAKE83_HIDDEN_OBJ4");
				dialog.UnHideNPC("F3CMLAKE83_HIDDEN_OBJ5");
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

		if (character.Inventory.HasItem("F3CMLAKE83_HIDDENQ1_ITEM2", 5))
		{
			character.Inventory.RemoveItem("F3CMLAKE83_HIDDENQ1_ITEM2", 5);
			await dialog.Msg("F3CMLAKE83_HQ1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

