//--- Melia Script -----------------------------------------------------------
// For the Revelator, by the Revelator
//--- Description -----------------------------------------------------------
// Quest to Examine the Royal Mausoleum Archives.
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

[QuestScript(8442)]
public class Quest8442Script : QuestScript
{
	protected override void Load()
	{
		SetId(8442);
		SetName("For the Revelator, by the Revelator");
		SetDescription("Examine the Royal Mausoleum Archives");

		AddPrerequisite(new LevelPrerequisite(90));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1800));

		AddDialogHook("ZACHA4F_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA4F_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA4F_SQ_01", "ZACHA4F_SQ_01", "I'll gather Wheelen's Marks", "I don't need it"))
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

		if (character.Inventory.HasItem("ZACHA4F_SQ_01_ITEM", 7))
		{
			character.Inventory.RemoveItem("ZACHA4F_SQ_01_ITEM", 7);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Wheelen's powerful energy is surrounding your body");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

