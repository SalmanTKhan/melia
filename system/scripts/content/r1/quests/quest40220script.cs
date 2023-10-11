//--- Melia Script -----------------------------------------------------------
// Cleaning the Strange Aura (2)
//--- Description -----------------------------------------------------------
// Quest to Look closely at other magic circles.
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

[QuestScript(40220)]
public class Quest40220Script : QuestScript
{
	protected override void Load()
	{
		SetId(40220);
		SetName("Cleaning the Strange Aura (2)");
		SetDescription("Look closely at other magic circles");

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_040"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_MAGIC02", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_RIMAS", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("FARM47_3_SQ_050_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

