//--- Melia Script -----------------------------------------------------------
// The Secret of the Lake (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(80246)]
public class Quest80246Script : QuestScript
{
	protected override void Load()
	{
		SetId(80246);
		SetName("The Secret of the Lake (1)");
		SetDescription("Talk to Resistance Deputy Commander Kron");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_03"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_04_ST", "F_3CMLAKE_85_MQ_04", "I'll go check it out.", "About the water point system.", "I don't think so."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_04_AFST");
				dialog.HideNPC("F_3CMLAKE_85_MQ_03_OBJ");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("F_3CMLAKE_85_MQ_04_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("F_3CMLAKE_85_MQ_04_ITEM", 2))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_85_MQ_04_ITEM", 2);
			await dialog.Msg("F_3CMLAKE_85_MQ_04_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

