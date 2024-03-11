//--- Melia Script -----------------------------------------------------------
// Recovering Energy
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80133)]
public class Quest80133Script : QuestScript
{
	protected override void Load()
	{
		SetId(80133);
		SetName("Recovering Energy");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_7"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 122220));

		AddDialogHook("LIMESTONECAVE_52_2_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_2_SERIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_8_start", "LIMESTONE_52_2_MQ_8", "Is there a way to restore Serija's energy?", "I think my work here is done, goodbye."))
		{
			case 1:
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("LIMESTONE_52_2_MQ_8_ST02");
				await dialog.Msg("Let's go.");
				await dialog.Msg("LIMESTONE_52_2_MQ_8_AG");
				// Func/LIMESTONE_52_2_REENTER_RUN;
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

		if (character.Inventory.HasItem("LIMESTONE_52_2_MQ_8_HEALSTONE", 1))
		{
			character.Inventory.RemoveItem("LIMESTONE_52_2_MQ_8_HEALSTONE", 1);
			await dialog.Msg("LIMESTONE_52_2_MQ_8_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

