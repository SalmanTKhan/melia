//--- Melia Script -----------------------------------------------------------
// Lindt's Matters
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Lindt.
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

[QuestScript(8038)]
public class Quest8038Script : QuestScript
{
	protected override void Load()
	{
		SetId(8038);
		SetName("Lindt's Matters");
		SetDescription("Talk to Mercenary Lindt");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q01"));

		AddObjective("collect0", "Collect 5 Lindt's Supplies(s)", new CollectItemObjective("ROKAS26_S_HEMOSTASIS", 5));
		AddDrop("ROKAS26_S_HEMOSTASIS", 4f, 41446, 57621, 57619);

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_LINT", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_LINT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_SUB_Q02_01", "ROKAS26_SUB_Q02", "I will help finding the supplies", "Tell him you will go since you passed the words"))
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

		if (character.Inventory.HasItem("ROKAS26_S_HEMOSTASIS", 5))
		{
			character.Inventory.RemoveItem("ROKAS26_S_HEMOSTASIS", 5);
			await dialog.Msg("ROKAS26_SUB_Q02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS26_SUB_Q03");
	}
}

