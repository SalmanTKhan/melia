//--- Melia Script -----------------------------------------------------------
// True Origin of the Curse (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Roana.
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

[QuestScript(20324)]
public class Quest20324Script : QuestScript
{
	protected override void Load()
	{
		SetId(20324);
		SetName("True Origin of the Curse (1)");
		SetDescription("Talk to Priest Roana");

		AddPrerequisite(new LevelPrerequisite(144));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 3744));

		AddDialogHook("PILGRIMROAD55_SQ05", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ07_selec01", "PILGRIMROAD55_SQ07", "I'll help", "Ignore and keep going on your way"))
		{
			case 1:
				await dialog.Msg("PILGRIMROAD55_SQ07_AG");
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

		await dialog.Msg("PILGRIMROAD55_SQ07_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

