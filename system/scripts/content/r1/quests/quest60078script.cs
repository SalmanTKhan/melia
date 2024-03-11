//--- Melia Script -----------------------------------------------------------
// Something to Give
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Izna.
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

[QuestScript(60078)]
public class Quest60078Script : QuestScript
{
	protected override void Load()
	{
		SetId(60078);
		SetName("Something to Give");
		SetDescription("Talk with Settler Izna");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 5 Rampar Mucus(s)", new CollectItemObjective("SIAU16_SQ_02_ITEM", 5));
		AddDrop("SIAU16_SQ_02_ITEM", 10f, "Sec_Bokchoy");

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));
		AddReward(new ItemReward("Drug_STA1_Q", 3));

		AddDialogHook("SIAULIAI16_IZNA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_IZNA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_02_01", "SIAU16_SQ_02", "I'll help you", "I don't have time for that"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

