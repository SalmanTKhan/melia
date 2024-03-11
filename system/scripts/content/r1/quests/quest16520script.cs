//--- Melia Script -----------------------------------------------------------
// Scarecrow's Hand (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Farmer Druva.
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

[QuestScript(16520)]
public class Quest16520Script : QuestScript
{
	protected override void Load()
	{
		SetId(16520);
		SetName("Scarecrow's Hand (1)");
		SetDescription("Talk to Farmer Druva");

		AddPrerequisite(new LevelPrerequisite(166));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4980));

		AddDialogHook("SIAULIAI_46_2_SQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_SQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_2_SQ_03_select", "SIAULIAI_46_2_SQ_03", "Alright, I'll help you", "I'm busy"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_2_SQ_03_start_prog");
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

		if (character.Inventory.HasItem("SIAULIAI_46_2_SQ_03_ITEM", 10))
		{
			character.Inventory.RemoveItem("SIAULIAI_46_2_SQ_03_ITEM", 10);
			await dialog.Msg("SIAULIAI_46_2_SQ_03_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_2_SQ_04");
	}
}

