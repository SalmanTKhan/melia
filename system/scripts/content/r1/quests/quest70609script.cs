//--- Melia Script -----------------------------------------------------------
// Slow Recovery
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

[QuestScript(70609)]
public class Quest70609Script : QuestScript
{
	protected override void Load()
	{
		SetId(70609);
		SetName("Slow Recovery");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(274));
		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ08"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11234));

		AddDialogHook("ABBEY416_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY416_SQ_09_start", "ABBEY41_6_SQ09", "Say that you'll try to find things that aren't spoiled", "Say that you are doubtful if there will be anything worthy of consumption"))
		{
			case 1:
				await dialog.Msg("ABBEY416_SQ_09_agree");
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

		if (character.Inventory.HasItem("ABBEY41_6_SQ09_ITEM", 5))
		{
			character.Inventory.RemoveItem("ABBEY41_6_SQ09_ITEM", 5);
			await dialog.Msg("ABBEY416_SQ_09_succ");
			dialog.HideNPC("ABBEY416_SQ_09_5");
			dialog.UnHideNPC("ABBEY416_SQ_10_1");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

