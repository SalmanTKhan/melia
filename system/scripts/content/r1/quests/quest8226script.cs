//--- Melia Script -----------------------------------------------------------
// Last Mission (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Officer's Spirit.
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

[QuestScript(8226)]
public class Quest8226Script : QuestScript
{
	protected override void Load()
	{
		SetId(8226);
		SetName("Last Mission (1)");
		SetDescription("Talk to the Officer's Spirit");

		AddPrerequisite(new LevelPrerequisite(107));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("KATYN71_OFFICER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN71_OFFICER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN71_MQ_02_01", "KATYN71_MQ_02", "It's a pity. Let's help him.", "About the Soul", "It's scary so reject it."))
		{
			case 1:
				await dialog.Msg("KATYN71_MQ_02_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("KATYN71_MQ_02_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("KATYN72_DUM_WO_01", 6))
		{
			character.Inventory.RemoveItem("KATYN72_DUM_WO_01", 6);
			await dialog.Msg("KATYN71_MQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN71_MQ_03");
	}
}

