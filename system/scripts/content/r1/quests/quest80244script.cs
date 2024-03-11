//--- Melia Script -----------------------------------------------------------
// Check the Pollution Levels
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Soldier Molan.
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

[QuestScript(80244)]
public class Quest80244Script : QuestScript
{
	protected override void Load()
	{
		SetId(80244);
		SetName("Check the Pollution Levels");
		SetDescription("Talk to Resistance Soldier Molan");

		AddPrerequisite(new LevelPrerequisite(362));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_02_2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_02_2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_02_3_ST", "F_3CMLAKE_85_MQ_02_3", "I'll do it.", "That sounds difficult."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_02_3_AFST");
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

		if (character.Inventory.HasItem("F_3CMLAKE_85_MQ_02_3_ITEM_02", 5))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_85_MQ_02_3_ITEM_02", 5);
			await dialog.Msg("F_3CMLAKE_85_MQ_02_3_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

