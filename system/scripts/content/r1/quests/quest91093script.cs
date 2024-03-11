//--- Melia Script -----------------------------------------------------------
// Collect the suppliers
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(91093)]
public class Quest91093Script : QuestScript
{
	protected override void Load()
	{
		SetId(91093);
		SetName("Collect the suppliers");
		SetDescription("Talk to the Centurion Master");

		AddPrerequisite(new LevelPrerequisite(462));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_1"));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));

		AddDialogHook("EP14_1_FCASTLE2_MQ_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE2_MQ_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE2_MQ_2_SNPC_DLG1", "EP14_1_FCASTLE2_MQ_2", "I'll find the suppliers", "It's pointless"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE2_MQ_2_SNPC_DLG2");
				dialog.UnHideNPC("EP14_1_FCASTLE2_MQ_2_DUMMYNPC_1");
				dialog.UnHideNPC("EP14_1_FCASTLE2_MQ_2_DUMMYNPC_2");
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

		if (character.Inventory.HasItem("EP14_1_FCASTLE2_MQ_2_ITEM1", 4) && character.Inventory.HasItem("EP14_1_FCASTLE2_MQ_2_ITEM2", 3))
		{
			character.Inventory.RemoveItem("EP14_1_FCASTLE2_MQ_2_ITEM1", 4);
			character.Inventory.RemoveItem("EP14_1_FCASTLE2_MQ_2_ITEM2", 3);
			await dialog.Msg("FadeOutIN/2000");
			dialog.UnHideNPC("EP14_1_F_CASTLE_2_MQ_DUMMY_1");
			dialog.HideNPC("EP14_1_FCASTLE2_MQ_2_DUMMYNPC_1");
			dialog.HideNPC("EP14_1_FCASTLE2_MQ_2_DUMMYNPC_2");
			await dialog.Msg("EP14_1_FCASTLE2_MQ_2_CNPC_DLG1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

