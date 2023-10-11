//--- Melia Script -----------------------------------------------------------
// For the Pilgrim (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Alisha.
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

[QuestScript(20319)]
public class Quest20319Script : QuestScript
{
	protected override void Load()
	{
		SetId(20319);
		SetName("For the Pilgrim (1)");
		SetDescription("Talk to Priest Alisha");

		AddPrerequisite(new LevelPrerequisite(143));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3718));

		AddDialogHook("PILGRIMROAD55_SQ02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ01_select01", "PILGRIMROAD55_SQ01", "I will get thistles for him", "I'm busy"))
		{
			case 1:
				await dialog.Msg("PILGRIMROAD55_SQ01_startnpc01");
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

		await dialog.Msg("PILGRIMROAD55_SQ01_succ01");
		// Func/PILGRIMROAD55_DRUG_MAKING;
		await dialog.Msg("PILGRIMROAD55_SQ01_succ02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

