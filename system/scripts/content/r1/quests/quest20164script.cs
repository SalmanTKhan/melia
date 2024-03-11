//--- Melia Script -----------------------------------------------------------
// Words of the King
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(20164)]
public class Quest20164Script : QuestScript
{
	protected override void Load()
	{
		SetId(20164);
		SetName("Words of the King");
		SetDescription("Talk to the Guardian Stone Statue");

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("ZACHA1F_MQ_01"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("ZACHARIEL33_GUARDIAN1", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHARIEL33_GUARDIAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_MQ_01_select_01", "ZACHA2F_MQ_01", "Retrieve the Royal Tombstone Piece", "I'll wait a little bit"))
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

		if (character.Inventory.HasItem("ZACHA2F_MQ_01_ITEM", 5))
		{
			character.Inventory.RemoveItem("ZACHA2F_MQ_01_ITEM", 5);
			await dialog.Msg("ZACHA2F_MQ_01_succ_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

