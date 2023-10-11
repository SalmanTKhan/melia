//--- Melia Script -----------------------------------------------------------
// Rexipher's True Colors (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Cyrenia Odell.
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

[QuestScript(20195)]
public class Quest20195Script : QuestScript
{
	protected override void Load()
	{
		SetId(20195);
		SetName("Rexipher's True Colors (4)");
		SetDescription("Talk to Historian Cyrenia Odell");

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_MQ6"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 17328));

		AddDialogHook("ROKAS_ODEL2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS30_MQ7_ST", "ROKAS30_MQ7", "I will go", "Ask her to wait a bit"))
		{
			case 1:
				await dialog.Msg("ROKAS30_MQ7_AC");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

