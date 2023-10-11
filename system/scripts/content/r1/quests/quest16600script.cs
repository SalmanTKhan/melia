//--- Melia Script -----------------------------------------------------------
// Addled Revelators
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Dazine.
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

[QuestScript(16600)]
public class Quest16600Script : QuestScript
{
	protected override void Load()
	{
		SetId(16600);
		SetName("Addled Revelators");
		SetDescription("Talk to Priest Dazine");

		AddPrerequisite(new LevelPrerequisite(169));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_2_MQ_05"));

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

		switch (await dialog.Select("SIAULIAI_46_1_MQ_01_select", "SIAULIAI_46_1_MQ_01", "Ask how to regain the symbol", "About the Seal in Spring Light Wood", "It's not related to me"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_1_MQ_01_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_46_1_add");
				break;
		}

		return HookResult.Break;
	}
}

