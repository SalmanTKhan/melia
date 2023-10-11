//--- Melia Script -----------------------------------------------------------
// The Legend of the Goddess' Seal (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Trija.
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

[QuestScript(80116)]
public class Quest80116Script : QuestScript
{
	protected override void Load()
	{
		SetId(80116);
		SetName("The Legend of the Goddess' Seal (2)");
		SetDescription("Talk to Kupole Trija");

		AddPrerequisite(new LevelPrerequisite(287));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_MQ_3"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12054));

		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_1_MQ_4_start", "LIMESTONE_52_1_MQ_4", "Can we use the Teleportation Magic Circle?", "I really don't think I'm the savior you're looking for."))
		{
			case 1:
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("LIMESTONE_52_1_MQ_ST02");
				await dialog.Msg("마법진을 복구하는 방법을 묻는다");
				await dialog.Msg("LIMESTONE_52_1_MQ_4_AG");
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

		if (character.Inventory.HasItem("LIMESTONE_52_1_MQ_4_CRYSTAL", 8))
		{
			character.Inventory.RemoveItem("LIMESTONE_52_1_MQ_4_CRYSTAL", 8);
			dialog.HideNPC("LIMSTONE_52_1_CRYSTAL_PIECE");
			await dialog.Msg("LIMESTONE_52_1_MQ_4_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

