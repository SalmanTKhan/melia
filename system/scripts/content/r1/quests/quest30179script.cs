//--- Melia Script -----------------------------------------------------------
// Shard Collection(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30179)]
public class Quest30179Script : QuestScript
{
	protected override void Load()
	{
		SetId(30179);
		SetName("Shard Collection(2)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_5"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11029));

		AddDialogHook("PRISON_81_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_81_MQ_6_select", "PRISON_81_MQ_6", "Say that you will purify the Shards", "I don't think that's necessary"))
		{
			case 1:
				await dialog.Msg("PRISON_81_MQ_6_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

