//--- Melia Script -----------------------------------------------------------
// The First Epitaph (2)
//--- Description -----------------------------------------------------------
// Quest to Examining the tablet.
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

[QuestScript(40580)]
public class Quest40580Script : QuestScript
{
	protected override void Load()
	{
		SetId(40580);
		SetName("The First Epitaph (2)");
		SetDescription("Examining the tablet");

		AddPrerequisite(new LevelPrerequisite(172));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_010"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("REMAINS37_2_MT01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_MT01", "BeforeEnd", BeforeEnd);
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

		await Task.Delay(300);
		await dialog.Msg("AITVARAS_RECORD_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

