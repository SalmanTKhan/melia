//--- Melia Script -----------------------------------------------------------
// The Forgotten Magic Circle
//--- Description -----------------------------------------------------------
// Quest to Look closely at the magic circle.
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

[QuestScript(40240)]
public class Quest40240Script : QuestScript
{
	protected override void Load()
	{
		SetId(40240);
		SetName("The Forgotten Magic Circle");
		SetDescription("Look closely at the magic circle");

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_050"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_MAGIC03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_MAGIC03", "BeforeEnd", BeforeEnd);
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FARM47_3_SQ_080");
	}
}

