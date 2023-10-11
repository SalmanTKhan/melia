//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Vaivora.
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

[QuestScript(60265)]
public class Quest60265Script : QuestScript
{
	protected override void Load()
	{
		SetId(60265);
		SetName("The History that Will Not Be Recorded (3)");
		SetDescription("Talk to Goddess Vaivora");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_2"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY484_NERINGA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB484_MQ_3_1", "FANTASYLIB484_MQ_3", "I'll collect it", "I'm not ready yet."))
		{
			case 1:
				await dialog.Msg("FANTASYLIB484_MQ_3_2");
				await dialog.Msg("FadeOutIN/1500");
				dialog.HideNPC("FLIBRARY484_VIVORA_NPC");
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

		if (character.Inventory.HasItem("FANTASYLIB484_MQ_3_ITEM", 12))
		{
			character.Inventory.RemoveItem("FANTASYLIB484_MQ_3_ITEM", 12);
			await dialog.Msg("FANTASYLIB484_MQ_3_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

