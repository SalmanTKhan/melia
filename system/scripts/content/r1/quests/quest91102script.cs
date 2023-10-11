//--- Melia Script -----------------------------------------------------------
// Demon's Defense Plan (1)
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

[QuestScript(91102)]
public class Quest91102Script : QuestScript
{
	protected override void Load()
	{
		SetId(91102);
		SetName("Demon's Defense Plan (1)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(464));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE3_MQ_1"));

		AddObjective("collect0", "Collect 1 Delmore Hamlet Defense Plan", new CollectItemObjective("EP14_1_FCASTLE3_MQ_2_ITEM1", 1));
		AddObjective("collect1", "Collect 1 Delmore Manor Defense Plan", new CollectItemObjective("EP14_1_FCASTLE3_MQ_2_ITEM2", 1));
		AddDrop("EP14_1_FCASTLE3_MQ_2_ITEM1", 1f, 59698, 59699, 59700);
		AddDrop("EP14_1_FCASTLE3_MQ_2_ITEM2", 1f, 59698, 59699, 59700);

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29232));

		AddDialogHook("EP14_1_FCASTLE3_MQ_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE3_MQ_2_SNPC_DLG1", "EP14_1_FCASTLE3_MQ_2", "I'll help you", "I'll work on other things first"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP14_1_FCASTLE3_MQ_1_NPC1");
				// Func/SCR_PAJAUTA_SUMMON;
				await dialog.Msg("EP14_1_FCASTLE3_MQ_2_SNPC_DLG2");
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

		if (character.Inventory.HasItem("EP14_1_FCASTLE3_MQ_2_ITEM1", 1) && character.Inventory.HasItem("EP14_1_FCASTLE3_MQ_2_ITEM2", 1))
		{
			character.Inventory.RemoveItem("EP14_1_FCASTLE3_MQ_2_ITEM1", 1);
			character.Inventory.RemoveItem("EP14_1_FCASTLE3_MQ_2_ITEM2", 1);
			await dialog.Msg("EP14_1_FCASTLE3_MQ_2_CNPC_DLG1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

