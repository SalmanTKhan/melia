//--- Melia Script -----------------------------------------------------------
// Complicated Preparations(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vilhelmas.
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

[QuestScript(70807)]
public class Quest70807Script : QuestScript
{
	protected override void Load()
	{
		SetId(70807);
		SetName("Complicated Preparations(3)");
		SetDescription("Talk to Vilhelmas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ07"));

		AddObjective("collect0", "Collect 18 Kugheri Paralysis Poison(s)", new CollectItemObjective("WHITETREES23_1_SQ08_ITEM", 18));
		AddDrop("WHITETREES23_1_SQ08_ITEM", 10f, "kucarry_Somy");

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES231_SQ_08_start", "WHITETREES23_1_SQ08", "I'll collect some right away", "Please wait a while"))
		{
			case 1:
				await dialog.Msg("WHITETREES231_SQ_08_agree");
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

		if (character.Inventory.HasItem("WHITETREES23_1_SQ08_ITEM", 18))
		{
			character.Inventory.RemoveItem("WHITETREES23_1_SQ08_ITEM", 18);
			await dialog.Msg("WHITETREES231_SQ_08_succ1");
			await dialog.Msg("FadeOutIN/2000");
			await dialog.Msg("WHITETREES231_SQ_08_succ2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

