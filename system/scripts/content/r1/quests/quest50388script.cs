//--- Melia Script -----------------------------------------------------------
// The Feline Post Town Case (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Secretary.
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

[QuestScript(50388)]
public class Quest50388Script : QuestScript
{
	protected override void Load()
	{
		SetId(50388);
		SetName("The Feline Post Town Case (2)");
		SetDescription("Talk to the Secretary");

		AddPrerequisite(new LevelPrerequisite(384));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_01"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 21724));

		AddDialogHook("NICO812_SUBQ_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICOPOLIS812_SQ02_START1", "F_NICOPOLIS_81_2_SQ_02", "I'll go looking for the Resident Logs.", "Let me know when the Resident Logs are found."))
		{
			case 1:
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

		if (character.Inventory.HasItem("NICOPOLIS_812_SUBQ3_ITEM1", 1) && character.Inventory.HasItem("NICOPOLIS_812_SUBQ3_ITEM2", 1) && character.Inventory.HasItem("NICOPOLIS_812_SUBQ3_ITEM3", 1) && character.Inventory.HasItem("NICOPOLIS_812_SUBQ3_ITEM4", 1))
		{
			character.Inventory.RemoveItem("NICOPOLIS_812_SUBQ3_ITEM1", 1);
			character.Inventory.RemoveItem("NICOPOLIS_812_SUBQ3_ITEM2", 1);
			character.Inventory.RemoveItem("NICOPOLIS_812_SUBQ3_ITEM3", 1);
			character.Inventory.RemoveItem("NICOPOLIS_812_SUBQ3_ITEM4", 1);
			character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
			await dialog.Msg("NICOPOLIS812_SQ02_SUCC_MSG1");
			await dialog.Msg("조사를 위해 입주 기록지를 달라고 한다");
			await dialog.Msg("NICOPOLIS812_SQ02_SUCC_2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

