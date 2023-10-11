//--- Melia Script -----------------------------------------------------------
// Black-colored Honor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(8403)]
public class Quest8403Script : QuestScript
{
	protected override void Load()
	{
		SetId(8403);
		SetName("Black-colored Honor (2)");
		SetDescription("Talk to the Guardian Stone Statue");

		AddPrerequisite(new LevelPrerequisite(87));
		AddPrerequisite(new CompletedPrerequisite("ZACHA3F_MQ_02"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1740));

		AddDialogHook("ZACHA3F_MQ03_MQ04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA3F_MQ_03_01", "ZACHA3F_MQ_03", "Destroy the corrupted Guardian", "I'll wait a little bit"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

