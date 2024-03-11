//--- Melia Script -----------------------------------------------------------
// Legs must work properly
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Brandon.
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

[QuestScript(70800)]
public class Quest70800Script : QuestScript
{
	protected override void Load()
	{
		SetId(70800);
		SetName("Legs must work properly");
		SetDescription("Talk to Refugee Brandon");

		AddPrerequisite(new LevelPrerequisite(316));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES231_SQ_01_start", "WHITETREES23_1_SQ01", "How can I help you?", "Say that it will be safe enough"))
		{
			case 1:
				await dialog.Msg("WHITETREES231_SQ_01_agree");
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

		if (character.Inventory.HasItem("WHITETREES23_1_SQ01_ITEM", 7))
		{
			character.Inventory.RemoveItem("WHITETREES23_1_SQ01_ITEM", 7);
			await dialog.Msg("NPCAin/WHITETREES231_SQ_01/std/1");
			await dialog.Msg("WHITETREES231_SQ_01_succ");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("WHITETREES231_SQ_01");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "There is something suspicious about the mysterious hunter.{nl}Go and ask him about what really happened.");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

