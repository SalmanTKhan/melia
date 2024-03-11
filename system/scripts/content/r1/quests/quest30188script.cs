//--- Melia Script -----------------------------------------------------------
// What Must Be Done (1)
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

[QuestScript(30188)]
public class Quest30188Script : QuestScript
{
	protected override void Load()
	{
		SetId(30188);
		SetName("What Must Be Done (1)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_4"));

		AddObjective("kill0", "Kill 13 Blue Temple Slave Assassin(s) or Blue Temple Slave Mage(s) or White Wendigo Archer(s)", new KillObjective(13, 57881, 57883, 57871));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11152));

		AddDialogHook("PRISON_82_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_82_MQ_5_select", "PRISON_82_MQ_5", "Say that you will not fail", "Say that it is impossible"))
		{
			case 1:
				await dialog.Msg("PRISON_82_MQ_5_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

