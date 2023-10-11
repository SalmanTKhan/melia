//--- Melia Script -----------------------------------------------------------
// Workshop Barrier(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30182)]
public class Quest30182Script : QuestScript
{
	protected override void Load()
	{
		SetId(30182);
		SetName("Workshop Barrier(1)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_8"));

		AddObjective("kill0", "Kill 20 Blue Nuka(s) or Blue Elma(s) or Brown Terra Imp Archer(s)", new KillObjective(20, 57985, 57987, 57952));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 132348));

		AddDialogHook("PRISON_81_NPC_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_81_MQ_9_select", "PRISON_81_MQ_9", "Say that you will deal with it all", "Ask for some time to recover before carrying on"))
		{
			case 1:
				await dialog.Msg("PRISON_81_MQ_9_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

