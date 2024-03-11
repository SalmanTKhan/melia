//--- Melia Script -----------------------------------------------------------
// Precious Cultivated Land
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80076)]
public class Quest80076Script : QuestScript
{
	protected override void Load()
	{
		SetId(80076);
		SetName("Precious Cultivated Land");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_10"));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_35_1_SQ_12_start", "SIAULIAI_35_1_SQ_12", "Alright", "I don't want to"))
		{
			case 1:
				dialog.UnHideNPC("SIAULIAI_35_1_SQ_12_HERB");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

