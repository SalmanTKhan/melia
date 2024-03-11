//--- Melia Script -----------------------------------------------------------
// Obtaining the Defensive Device Lever (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72184)]
public class Quest72184Script : QuestScript
{
	protected override void Load()
	{
		SetId(72184);
		SetName("Obtaining the Defensive Device Lever (1)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_30"));

		AddObjective("collect0", "Collect 6 Written Instructions(s)", new CollectItemObjective("STARTOWER_89_MQ_40_ITEM", 6));
		AddDrop("STARTOWER_89_MQ_40_ITEM", 10f, 59080, 59081, 59083, 59082);

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19500));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_89_MQ_40_DLG1", "STARTOWER_89_MQ_40", "Alright", "I need time to rest."))
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

		if (character.Inventory.HasItem("STARTOWER_89_MQ_40_ITEM", 6))
		{
			character.Inventory.RemoveItem("STARTOWER_89_MQ_40_ITEM", 6);
			await dialog.Msg("STARTOWER_89_MQ_40_DLG3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

