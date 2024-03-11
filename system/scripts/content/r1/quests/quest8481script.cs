//--- Melia Script -----------------------------------------------------------
// Mage Tower 2nd Floor (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8481)]
public class Quest8481Script : QuestScript
{
	protected override void Load()
	{
		SetId(8481);
		SetName("Mage Tower 2nd Floor (4)");
		SetDescription("Talk to Grita");

		AddPrerequisite(new LevelPrerequisite(116));
		AddPrerequisite(new CompletedPrerequisite("FTOWER42_MQ_03"));

		AddObjective("collect0", "Collect 11 Flame Source(s)", new CollectItemObjective("FTOWER42_MQ_04_ITEM", 11));
		AddDrop("FTOWER42_MQ_04_ITEM", 5f, 57042, 47398, 47461, 47402, 57051);

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER42_MQ_04_01", "FTOWER42_MQ_04", "I'll gather the Fire Sources.", "Decline"))
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

		if (character.Inventory.HasItem("FTOWER42_MQ_04_ITEM", 11))
		{
			character.Inventory.RemoveItem("FTOWER42_MQ_04_ITEM", 11);
			await dialog.Msg("FTOWER42_MQ_04_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER42_MQ_05");
	}
}

