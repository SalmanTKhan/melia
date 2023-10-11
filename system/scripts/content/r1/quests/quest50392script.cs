//--- Melia Script -----------------------------------------------------------
// The Feline Post Town Case (6)
//--- Description -----------------------------------------------------------
// Quest to Investigate Burnt Clothes.
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

[QuestScript(50392)]
public class Quest50392Script : QuestScript
{
	protected override void Load()
	{
		SetId(50392);
		SetName("The Feline Post Town Case (6)");
		SetDescription("Investigate Burnt Clothes");

		AddPrerequisite(new LevelPrerequisite(384));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_05"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 22500));

		AddDialogHook("NICO812_SUBQ_NPC6", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("NICOPOLIS812_SQ06_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

