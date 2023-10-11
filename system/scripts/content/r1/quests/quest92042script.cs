//--- Melia Script -----------------------------------------------------------
// Good Idea (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(92042)]
public class Quest92042Script : QuestScript
{
	protected override void Load()
	{
		SetId(92042);
		SetName("Good Idea (3)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_SQ_03"));

		AddObjective("collect0", "Collect 10 Someone's Pickaxe(s)", new CollectItemObjective("EP13_F_SIAULIAI_2_SQ_ITEM_01", 10));
		AddDrop("EP13_F_SIAULIAI_2_SQ_ITEM_01", 10f, "darbas_miner");

		AddObjective("kill0", "Kill 10 Darbas Miner(s)", new KillObjective(10, MonsterId.Darbas_Miner));

		AddReward(new ItemReward("Vis", 28024));
		AddReward(new ItemReward("expCard18", 2));

		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_SQ_04_1", "EP13_F_SIAULIAI_2_SQ_04", "Alright", "That's too much"))
		{
			case 1:
				await dialog.Msg("BalloonText/EP13_F_SIAULIAI_2_SQ_05_1_1/3");
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

		if (character.Inventory.HasItem("EP13_F_SIAULIAI_2_SQ_ITEM_01", 10))
		{
			character.Inventory.RemoveItem("EP13_F_SIAULIAI_2_SQ_ITEM_01", 10);
			await dialog.Msg("EP13_F_SIAULIAI_2_SQ_04_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

