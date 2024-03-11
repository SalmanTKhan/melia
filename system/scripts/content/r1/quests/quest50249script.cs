//--- Melia Script -----------------------------------------------------------
// Things needed to repair the tent
//--- Description -----------------------------------------------------------
// Quest to Talk to Ohla.
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

[QuestScript(50249)]
public class Quest50249Script : QuestScript
{
	protected override void Load()
	{
		SetId(50249);
		SetName("Things needed to repair the tent");
		SetDescription("Talk to Ohla");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES56_1_SQ1"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15369));

		AddDialogHook("WHITETREES561_SUBQ_NPC1_2", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES561_SUBQ_NPC1_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES561_SUBQ2_START1", "WHITETREES56_1_SQ2", "How could I get the thread?", "Well, sorry I cannot help you on that. How asking about someone else?"))
		{
			case 1:
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("WHITETREES561_SUBQ2_AGREE1");
				await dialog.Msg("감사는 나중에 하고, 일단 실을 구할 방법이 무엇인지 묻는다");
				await dialog.Msg("WHITETREES561_SUBQ2_AGREE2");
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

		if (character.Inventory.HasItem("WHITETREES561_SUBQ2_ITEM", 10))
		{
			character.Inventory.RemoveItem("WHITETREES561_SUBQ2_ITEM", 10);
			await dialog.Msg("WHITETREES561_SUBQ2_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

