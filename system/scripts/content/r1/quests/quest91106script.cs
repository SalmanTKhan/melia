//--- Melia Script -----------------------------------------------------------
// Demon's Defense Plan (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91106)]
public class Quest91106Script : QuestScript
{
	protected override void Load()
	{
		SetId(91106);
		SetName("Demon's Defense Plan (4)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(464));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE3_MQ_5"));

		AddObjective("collect0", "Collect 1 Delmore Outskirts Defense Plan", new CollectItemObjective("EP14_1_FCASTLE3_MQ_6_ITEM1", 1));
		AddDrop("EP14_1_FCASTLE3_MQ_6_ITEM1", 1f, 59698, 59699, 59700);

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29232));

		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE3_MQ_6_SNPC_DLG1", "EP14_1_FCASTLE3_MQ_6", "Let's trace them", "Wait for a while"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE3_MQ_6_SNPC_DLG2");
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

		if (character.Inventory.HasItem("EP14_1_FCASTLE3_MQ_6_ITEM1", 1))
		{
			character.Inventory.RemoveItem("EP14_1_FCASTLE3_MQ_6_ITEM1", 1);
			await dialog.Msg("EP14_1_FCASTLE3_MQ_6_CNPC_DLG1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

