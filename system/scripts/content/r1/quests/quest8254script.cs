//--- Melia Script -----------------------------------------------------------
// Recycling (1)
//--- Description -----------------------------------------------------------
// Quest to Check the epitaph of the Royal Mausoleum.
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

[QuestScript(8254)]
public class Quest8254Script : QuestScript
{
	protected override void Load()
	{
		SetId(8254);
		SetName("Recycling (1)");
		SetDescription("Check the epitaph of the Royal Mausoleum");

		AddPrerequisite(new LevelPrerequisite(81));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1620));

		AddDialogHook("ZACHA1F_MQ_04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA1F_MQ_04_01", "ZACHA1F_MQ_04", "Let's remove those Guardians from the Royal Mausoleum", "I'll wait a little bit"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

