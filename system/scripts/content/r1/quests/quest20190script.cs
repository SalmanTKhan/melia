//--- Melia Script -----------------------------------------------------------
// Historian Rexipher's Identity
//--- Description -----------------------------------------------------------
// Quest to Ask Historian Cyrenia Odell about Rexipher's whereabouts.
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

[QuestScript(20190)]
public class Quest20190Script : QuestScript
{
	protected override void Load()
	{
		SetId(20190);
		SetName("Historian Rexipher's Identity");
		SetDescription("Ask Historian Cyrenia Odell about Rexipher's whereabouts");

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_MQ1_BRIDGE"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));

		AddDialogHook("ROKAS30_ODEL", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS30_MQ2_select01", "ROKAS30_MQ2", "I'm sure that is the name", "Stop looking for Rexipher"))
		{
			case 1:
				await dialog.Msg("ROKAS30_MQ2_start01");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

