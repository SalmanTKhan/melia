//--- Melia Script -----------------------------------------------------------
// Wizard Tulis' Ore Research (3)
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

[QuestScript(50163)]
public class Quest50163Script : QuestScript
{
	protected override void Load()
	{
		SetId(50163);
		SetName("Wizard Tulis' Ore Research (3)");
		SetDescription("Talk to Wizard Tulis");

		AddPrerequisite(new LevelPrerequisite(242));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_71_SQ6"));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 80586));

		AddDialogHook("TABLE71_PEAPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ7_startnpc1", "TABLELAND_71_SQ7", "Is there a way?", "I'll be on my way now."))
		{
			case 1:
				await dialog.Msg("TABLELAND_71_SQ7_startnpc2");
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

		await dialog.Msg("TABLELAND_71_SQ7_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

