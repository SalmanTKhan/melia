//--- Melia Script -----------------------------------------------------------
// Warning to the Upper Echelon
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Clark.
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

[QuestScript(70528)]
public class Quest70528Script : QuestScript
{
	protected override void Load()
	{
		SetId(70528);
		SetName("Warning to the Upper Echelon");
		SetDescription("Talk to Believer Clark");

		AddPrerequisite(new LevelPrerequisite(261));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_2_SQ08"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10701));

		AddDialogHook("PILGRIM412_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM412_SQ_09_start", "PILGRIM41_2_SQ09", "Say that you will gather enough", "Say that they should do it since it is a simple task"))
		{
			case 1:
				await dialog.Msg("PILGRIM412_SQ_09_prog");
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

		if (character.Inventory.HasItem("PILGRIM41_2_SQ09_ITEM", 30))
		{
			character.Inventory.RemoveItem("PILGRIM41_2_SQ09_ITEM", 30);
			await dialog.Msg("PILGRIM412_SQ_09_succ1");
			// Func/SCR_PILGRIM412_SQ_09_RUN;
			await dialog.Msg("PILGRIM412_SQ_09_succ2");
			dialog.HideNPC("PILGRIM412_SQ_07");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

