//--- Melia Script -----------------------------------------------------------
// The Restrained Spirit of Zanas(2)
//--- Description -----------------------------------------------------------
// Quest to Rescue Zanas' Spirit by disarming the Magic Circle of Restrainment.
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

[QuestScript(30177)]
public class Quest30177Script : QuestScript
{
	protected override void Load()
	{
		SetId(30177);
		SetName("The Restrained Spirit of Zanas(2)");
		SetDescription("Rescue Zanas' Spirit by disarming the Magic Circle of Restrainment");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_3"));
		AddPrerequisite(new ItemPrerequisite("PRISON_81_MQ_3_ITEM", -100));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));

		AddDialogHook("PRISON_81_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PRISON_81_MQ_4_succ");
		dialog.HideNPC("PRISON_81_NPC_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

