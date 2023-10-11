//--- Melia Script -----------------------------------------------------------
// Storage Room Barrier(1)
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

[QuestScript(30162)]
public class Quest30162Script : QuestScript
{
	protected override void Load()
	{
		SetId(30162);
		SetName("Storage Room Barrier(1)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(262));
		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_8"));

		AddObjective("kill0", "Kill 20 Blue Nuo(s) or Red Socket Archer(s) or Blue Terra Imp Mage(s)", new KillObjective(20, 57983, 57932, 57951));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 118162));

		AddDialogHook("PRISON_79_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_79_MQ_9_select", "PRISON_79_MQ_9", "I'll defeat the monsters", "Say that you don't think there will be much of a problem"))
		{
			case 1:
				await dialog.Msg("PRISON_79_MQ_9_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

