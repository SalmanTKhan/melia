//--- Melia Script -----------------------------------------------------------
// Confiscated Prisoner Belongings
//--- Description -----------------------------------------------------------
// Quest to Check the walls of the Long Sentence Prison Cell.
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

[QuestScript(30199)]
public class Quest30199Script : QuestScript
{
	protected override void Load()
	{
		SetId(30199);
		SetName("Confiscated Prisoner Belongings");
		SetDescription("Check the walls of the Long Sentence Prison Cell");

		AddPrerequisite(new LevelPrerequisite(265));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10865));
		AddReward(new ItemReward("Drug_Premium_HP1", 20));

		AddDialogHook("PRISON_80_SQ_OBJ_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_80_SQ_1_select1", "PRISON_80_SQ_1"))
		{
		}

		return HookResult.Break;
	}
}

