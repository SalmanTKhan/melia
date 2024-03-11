//--- Melia Script -----------------------------------------------------------
// Supply Room's Secret Device
//--- Description -----------------------------------------------------------
// Quest to Check the Secret Device at the Central Assembly Area.
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

[QuestScript(30197)]
public class Quest30197Script : QuestScript
{
	protected override void Load()
	{
		SetId(30197);
		SetName("Supply Room's Secret Device");
		SetDescription("Check the Secret Device at the Central Assembly Area");

		AddPrerequisite(new LevelPrerequisite(262));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10742));
		AddReward(new ItemReward("Drug_Haste1_event", 5));

		AddDialogHook("PRISON_79_SQ_OBJ_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_SQ_OBJ_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


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

