//--- Melia Script -----------------------------------------------------------
// Prisoner Contraband
//--- Description -----------------------------------------------------------
// Quest to Check the Writings on the Wall.
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

[QuestScript(30195)]
public class Quest30195Script : QuestScript
{
	protected override void Load()
	{
		SetId(30195);
		SetName("Prisoner Contraband");
		SetDescription("Check the Writings on the Wall");

		AddPrerequisite(new LevelPrerequisite(259));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10360));
		AddReward(new ItemReward("Drug_Premium_HP1", 20));

		AddDialogHook("PRISON_78_SQ_OBJ_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_78_SQ_1_select1", "PRISON_78_SQ_1"))
		{
		}

		return HookResult.Break;
	}
}

