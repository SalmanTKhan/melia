//--- Melia Script -----------------------------------------------------------
// Symbol of Goddess Austeja
//--- Description -----------------------------------------------------------
// Quest to Restore the symbol at the Austeja Altar .
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

[QuestScript(16610)]
public class Quest16610Script : QuestScript
{
	protected override void Load()
	{
		SetId(16610);
		SetName("Symbol of Goddess Austeja");
		SetDescription("Restore the symbol at the Austeja Altar ");

		AddPrerequisite(new LevelPrerequisite(169));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_1_MQ_01"));
		AddPrerequisite(new ItemPrerequisite("SIAULIAI_46_1_MQ_01_ITEM", -100));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_ALTAR", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_1_MQ01_NPC", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("SIAULIAI_46_1_MQ_02_ITEM", 1))
		{
			character.Inventory.RemoveItem("SIAULIAI_46_1_MQ_02_ITEM", 1);
			await dialog.Msg("SIAULIAI_46_1_MQ_02_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_1_MQ_03");
	}
}

