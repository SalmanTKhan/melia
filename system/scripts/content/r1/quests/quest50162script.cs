//--- Melia Script -----------------------------------------------------------
// Wizard Tulis' Ore Research (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Tulis.
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

[QuestScript(50162)]
public class Quest50162Script : QuestScript
{
	protected override void Load()
	{
		SetId(50162);
		SetName("Wizard Tulis' Ore Research (2)");
		SetDescription("Talk to Wizard Tulis");

		AddPrerequisite(new LevelPrerequisite(242));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_71_SQ5"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 8954));

		AddDialogHook("TABLE71_PEAPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ6_startnpc1", "TABLELAND_71_SQ6", "I'll help you out", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("TABLELAND_71_SQ6_startnpc2");
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

		await dialog.Msg("TABLELAND_71_SQ6_succ1");
		// Func/TABLELAND71_SUBQ6_COMPLETE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

