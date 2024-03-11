//--- Melia Script -----------------------------------------------------------
// Destroyed Seal Tower (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Dazine.
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

[QuestScript(16630)]
public class Quest16630Script : QuestScript
{
	protected override void Load()
	{
		SetId(16630);
		SetName("Destroyed Seal Tower (1)");
		SetDescription("Talk to Priest Dazine");

		AddPrerequisite(new LevelPrerequisite(169));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_1_MQ_03"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_MQ01_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_1_MQ_04_select", "SIAULIAI_46_1_MQ_04", "I will restore the seal", "Why the seal is destroyed", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_1_MQ_04_start_prog");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_46_1_MQ_04_add");
				break;
		}

		return HookResult.Break;
	}
}

