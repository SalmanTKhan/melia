//--- Melia Script -----------------------------------------------------------
// Reactivating the Water Facility (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Ramunas.
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

[QuestScript(80278)]
public class Quest80278Script : QuestScript
{
	protected override void Load()
	{
		SetId(80278);
		SetName("Reactivating the Water Facility (1)");
		SetDescription("Talk to Elder Ramunas");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_01"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_SQ_01_ST", "F_3CMLAKE_86_SQ_01", "I'll go find it.", "I don't think that's going to work."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_SQ_01_AFST");
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

		if (character.Inventory.HasItem("F_3CMLAKE86_SQ1_ITEM", 9))
		{
			character.Inventory.RemoveItem("F_3CMLAKE86_SQ1_ITEM", 9);
			await dialog.Msg("F_3CMLAKE_86_SQ_01_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

