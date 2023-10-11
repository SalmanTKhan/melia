//--- Melia Script -----------------------------------------------------------
// Power of the Seed
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Medeina.
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

[QuestScript(80423)]
public class Quest80423Script : QuestScript
{
	protected override void Load()
	{
		SetId(80423);
		SetName("Power of the Seed");
		SetDescription("Talk to Goddess Medeina");

		AddPrerequisite(new LevelPrerequisite(411));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_1_MQ_03"), new CompletedPrerequisite("F_MAPLE_24_1_MQ_04"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23427));

		AddDialogHook("F_MAPLE_241_MQ_MEDEINA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_241_MQ_MEDEINA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_1_MQ_04_1_ST", "F_MAPLE_24_1_MQ_04_1", "I'll give it a shot.", "No, I don't think I can do that."))
		{
			case 1:
				await dialog.Msg("F_MAPLE_24_1_MQ_04_1_AFST");
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

		if (character.Inventory.HasItem("F_MAPLE_241_MQ_04_1_ITEM", 5))
		{
			character.Inventory.RemoveItem("F_MAPLE_241_MQ_04_1_ITEM", 5);
			await dialog.Msg("F_MAPLE_24_1_MQ_04_1_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

