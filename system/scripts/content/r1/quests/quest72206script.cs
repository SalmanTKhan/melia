//--- Melia Script -----------------------------------------------------------
// Building Initiation (8)
//--- Description -----------------------------------------------------------
// Quest to Use the Key You Found to Search for the Second key.
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

[QuestScript(72206)]
public class Quest72206Script : QuestScript
{
	protected override void Load()
	{
		SetId(72206);
		SetName("Building Initiation (8)");
		SetDescription("Use the Key You Found to Search for the Second key");

		AddPrerequisite(new LevelPrerequisite(382));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_91_MQ_70"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20246));

		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("STARTOWER_91_MQ_80_ITEM", 1))
		{
			character.Inventory.RemoveItem("STARTOWER_91_MQ_80_ITEM", 1);
			await dialog.Msg("STARTOWER_91_MQ_80_DLG2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/SCR_STARTOWER_91_MQ_80_ITEM_CHECK;
	}
}

