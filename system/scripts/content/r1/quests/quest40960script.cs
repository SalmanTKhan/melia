//--- Melia Script -----------------------------------------------------------
// Something Carved on the Pillar
//--- Description -----------------------------------------------------------
// Quest to Look at the pillar.
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

[QuestScript(40960)]
public class Quest40960Script : QuestScript
{
	protected override void Load()
	{
		SetId(40960);
		SetName("Something Carved on the Pillar");
		SetDescription("Look at the pillar");

		AddPrerequisite(new LevelPrerequisite(103));

		AddObjective("collect0", "Collect 40 Mysteriously Light Emanating Crystal(s)", new CollectItemObjective("ROKAS_36_1_SQ_020_ITEM_1", 40));
		AddDrop("ROKAS_36_1_SQ_020_ITEM_1", 7f, 58128, 58129, 57661);

		AddReward(new ExpReward(294852, 294852));
		AddReward(new ItemReward("expCard6", 6));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("ROKAS_36_1_PILLA02", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_36_1_PILLA02", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("ROKAS_36_1_SQ_020_ITEM_1", 40))
		{
			character.Inventory.RemoveItem("ROKAS_36_1_SQ_020_ITEM_1", 40);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The crystal emanating the mysterious ray begins to shine brightly!");
			// Func/ROKAS_36_1_SQ_020_COMP_FUNC;
			ZoneServer.Instance.World.FindNPC("ROKAS_36_1_PILLA02")?.PlayEffectLocal(character.Connection, "F_ground139_light_green", 1f, "BOT");
			await Task.Delay(2000);
			await dialog.Msg("ROKAS_36_1_SQ_020_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

