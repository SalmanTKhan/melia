//--- Melia Script -----------------------------------------------------------
// Hidden Place (1)
//--- Description -----------------------------------------------------------
// Quest to Read the Secret Location Manual.
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

[QuestScript(8433)]
public class Quest8433Script : QuestScript
{
	protected override void Load()
	{
		SetId(8433);
		SetName("Hidden Place (1)");
		SetDescription("Read the Secret Location Manual");

		AddPrerequisite(new LevelPrerequisite(85));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("ZACHA2F_SQ", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_SQ_01_01", "ZACHA2F_SQ_01", "Let's gather the force of the guardians and find the hidden treasure", "Not interested"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

