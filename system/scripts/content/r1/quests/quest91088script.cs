//--- Melia Script -----------------------------------------------------------
// Reassemble the Troop (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(91088)]
public class Quest91088Script : QuestScript
{
	protected override void Load()
	{
		SetId(91088);
		SetName("Reassemble the Troop (3)");
		SetDescription("Talk to the Centurion Master");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE1_MQ_3"));

		AddObjective("collect0", "Collect 5 Royal Army Sword(s)", new CollectItemObjective("EP14_1_FCASTLE1_MQ_4_ITEM1", 5));
		AddObjective("collect1", "Collect 5 Royal Army Spear(s)", new CollectItemObjective("EP14_1_FCASTLE1_MQ_4_ITEM2", 5));
		AddObjective("collect2", "Collect 10 Royal Army Arrow(s)", new CollectItemObjective("EP14_1_FCASTLE1_MQ_4_ITEM3", 10));
		AddDrop("EP14_1_FCASTLE1_MQ_4_ITEM1", 7f, 59692, 59693, 59694);
		AddDrop("EP14_1_FCASTLE1_MQ_4_ITEM2", 7f, 59692, 59693, 59694);
		AddDrop("EP14_1_FCASTLE1_MQ_4_ITEM3", 7f, 59692, 59693, 59694);

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP14_1_F_CASTLE_1_FOLLOW_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_1_FOLLOW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE1_MQ_4_SNPC_DLG1", "EP14_1_FCASTLE1_MQ_4", "Let's move", "Wait for a while"))
		{
			case 1:
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

		if (character.Inventory.HasItem("EP14_1_FCASTLE1_MQ_4_ITEM1", 5) && character.Inventory.HasItem("EP14_1_FCASTLE1_MQ_4_ITEM2", 5) && character.Inventory.HasItem("EP14_1_FCASTLE1_MQ_4_ITEM3", 10))
		{
			character.Inventory.RemoveItem("EP14_1_FCASTLE1_MQ_4_ITEM1", 5);
			character.Inventory.RemoveItem("EP14_1_FCASTLE1_MQ_4_ITEM2", 5);
			character.Inventory.RemoveItem("EP14_1_FCASTLE1_MQ_4_ITEM3", 10);
			await dialog.Msg("EP14_1_FCASTLE1_MQ_4_CNPC_DLG1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

