//--- Melia Script -----------------------------------------------------------
// Activate the Obelisk (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Village Priest.
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

[QuestScript(20277)]
public class Quest20277Script : QuestScript
{
	protected override void Load()
	{
		SetId(20277);
		SetName("Activate the Obelisk (1)");
		SetDescription("Talk to the Village Priest");

		AddPrerequisite(new LevelPrerequisite(49));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_2_MQ01"));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("HUEVILLAGE_58_2_MQ02_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_2_MQ02_select01", "HUEVILLAGE_58_2_MQ02", "Ask how to restore it", "Just leave"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_2_MQ02_select01_Q");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

