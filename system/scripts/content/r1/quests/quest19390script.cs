//--- Melia Script -----------------------------------------------------------
// Security Guard's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Look for the Security Guard.
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

[QuestScript(19390)]
public class Quest19390Script : QuestScript
{
	protected override void Load()
	{
		SetId(19390);
		SetName("Security Guard's Favor (2)");
		SetDescription("Look for the Security Guard");

		AddPrerequisite(new LevelPrerequisite(78));
		AddPrerequisite(new CompletedPrerequisite("ROKAS31_SUB_02"));

		AddObjective("collect0", "Collect 1 Shabby-Looking Necklace", new CollectItemObjective("ROKAS31_SUB_03_CERT", 1));
		AddDrop("ROKAS31_SUB_03_CERT", 10f, "warleader_hogma");

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Drug_SP2_Q", 30));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_SUB", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_SUB", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS31_SUB_03_ST", "ROKAS31_SUB_03", "Do not worry I'll collect them", "Take care of such things by yourself"))
		{
			case 1:
				await dialog.Msg("ROKAS31_SUB_03_AC");
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

		if (character.Inventory.HasItem("ROKAS31_SUB_03_CERT", 1))
		{
			character.Inventory.RemoveItem("ROKAS31_SUB_03_CERT", 1);
			await dialog.Msg("ROKAS31_SUB_03_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

