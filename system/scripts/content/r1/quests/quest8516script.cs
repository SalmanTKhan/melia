//--- Melia Script -----------------------------------------------------------
// Lunatic Wizard (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8516)]
public class Quest8516Script : QuestScript
{
	protected override void Load()
	{
		SetId(8516);
		SetName("Lunatic Wizard (4)");
		SetDescription("Talk to Grita");

		AddPrerequisite(new LevelPrerequisite(119));
		AddPrerequisite(new CompletedPrerequisite("FTOWER43_MQ_03"));

		AddObjective("collect0", "Collect 6 Red Infrorocktor Core(s)", new CollectItemObjective("FTOWER43_MQ_07_ITEM", 6));
		AddDrop("FTOWER43_MQ_07_ITEM", 10f, "InfroRocktor_red");

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 31416));

		AddDialogHook("FTOWER43_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER43_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER43_MQ_07_01", "FTOWER43_MQ_07", "What are you going to do if you can't use the spell?", "Why the spell can't be used", "I need some time to think"))
		{
			case 1:
				await dialog.Msg("FTOWER43_MQ_07_02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FTOWER43_MQ_07_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FTOWER43_MQ_07_ITEM", 6))
		{
			character.Inventory.RemoveItem("FTOWER43_MQ_07_ITEM", 6);
			await dialog.Msg("FTOWER43_MQ_07_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER43_MQ_06");
	}
}

