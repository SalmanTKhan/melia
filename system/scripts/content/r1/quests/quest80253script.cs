//--- Melia Script -----------------------------------------------------------
// The Fatal Grass (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Resistance Soldier Mait.
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

[QuestScript(80253)]
public class Quest80253Script : QuestScript
{
	protected override void Load()
	{
		SetId(80253);
		SetName("The Fatal Grass (1)");
		SetDescription("Talk to the Resistance Soldier Mait");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_03"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_01_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_01_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_SQ_01_ST", "F_3CMLAKE_85_SQ_01", "Leave it to me.", "Sorry, I'll have to refuse."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_SQ_01_AFST");
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

		if (character.Inventory.HasItem("F_3CMLAKE_85_SQ_01_ITEM", 8))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_85_SQ_01_ITEM", 8);
			await dialog.Msg("F_3CMLAKE_85_SQ_01_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

