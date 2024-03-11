//--- Melia Script -----------------------------------------------------------
// Talk to the Battle Commander (2)
//--- Description -----------------------------------------------------------
// Quest to Go to the Hanaming habitat.
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

[QuestScript(1021)]
public class Quest1021Script : QuestScript
{
	protected override void Load()
	{
		SetId(1021);
		SetName("Talk to the Battle Commander (2)");
		SetDescription("Go to the Hanaming habitat");

		AddPrerequisite(new LevelPrerequisite(3));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_SOLDIER3"));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));
		AddReward(new ItemReward("Drug_STA1_Q", 3));
		AddReward(new ItemReward("Vis", 39));

		AddDialogHook("SIAUL_WEST_SOL3", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_SOL3", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("leaf_hanaming", 3))
		{
			character.Inventory.RemoveItem("leaf_hanaming", 3);
			await dialog.Msg("SIAUL_WEST_HAMING_LEAF_dlg1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

