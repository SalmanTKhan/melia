//--- Melia Script -----------------------------------------------------------
// Collapsed Protection System
//--- Description -----------------------------------------------------------
// Quest to Read the Royal Mausoleum Foundation Stone.
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

[QuestScript(8600)]
public class Quest8600Script : QuestScript
{
	protected override void Load()
	{
		SetId(8600);
		SetName("Collapsed Protection System");
		SetDescription("Read the Royal Mausoleum Foundation Stone");

		AddPrerequisite(new LevelPrerequisite(81));
		AddPrerequisite(new CompletedPrerequisite("ROKAS31_REXITHER3"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1620));

		AddDialogHook("ZACHA1F_MQ_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA1F_MQ_01_01", "ZACHA1F_MQ_01", "Repair the broken Royal Mausoleum Guardian", "I'll wait a little bit"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

