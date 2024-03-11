//--- Melia Script -----------------------------------------------------------
// Kugheri Restricted Area
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70840)]
public class Quest70840Script : QuestScript
{
	protected override void Load()
	{
		SetId(70840);
		SetName("Kugheri Restricted Area");
		SetDescription("Talk to Indraja");

		AddPrerequisite(new LevelPrerequisite(323));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES233_SQ_01_start", "WHITETREES23_3_SQ01", "How can I help you?", "Refuse as you are too busy"))
		{
			case 1:
				await dialog.Msg("WHITETREES233_SQ_01_agree");
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

		if (character.Inventory.HasItem("WHITETREES23_3_SQ01_ITEM", 8))
		{
			character.Inventory.RemoveItem("WHITETREES23_3_SQ01_ITEM", 8);
			character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
			await dialog.Msg("WHITETREES233_SQ_01_succ1");
			await dialog.Msg("맞다고 한다.");
			await dialog.Msg("WHITETREES233_SQ_01_succ2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

