//--- Melia Script -----------------------------------------------------------
// The Road Back(2)
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

[QuestScript(30175)]
public class Quest30175Script : QuestScript
{
	protected override void Load()
	{
		SetId(30175);
		SetName("The Road Back(2)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_1"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11029));

		AddDialogHook("PRISON_81_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_81_MQ_2_select", "PRISON_81_MQ_2", "Ask what the special Crest is", "Say that you should wait until the Demon Magic is undone"))
		{
			case 1:
				await dialog.Msg("PRISON_81_MQ_2_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

