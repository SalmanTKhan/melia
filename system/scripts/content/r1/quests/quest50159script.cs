//--- Melia Script -----------------------------------------------------------
// Setbacks (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jamelhan.
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

[QuestScript(50159)]
public class Quest50159Script : QuestScript
{
	protected override void Load()
	{
		SetId(50159);
		SetName("Setbacks (3)");
		SetDescription("Talk to Jamelhan");

		AddPrerequisite(new LevelPrerequisite(242));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_71_SQ2_2"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 8954));

		AddDialogHook("TABLE71_PEAPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ3_startnpc1", "TABLELAND_71_SQ3", "I'll sterilize the miners' wounds.", "I'll wait then"))
		{
			case 1:
				await dialog.Msg("TABLELAND_71_SQ3_startnpc2");
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

		await dialog.Msg("TABLELAND_71_SQ3_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

