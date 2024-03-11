//--- Melia Script -----------------------------------------------------------
// Too Late Already
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Siute.
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

[QuestScript(80148)]
public class Quest80148Script : QuestScript
{
	protected override void Load()
	{
		SetId(80148);
		SetName("Too Late Already");
		SetDescription("Talk to Kupole Siute");

		AddPrerequisite(new LevelPrerequisite(294));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_10"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12348));

		AddDialogHook("LIMESTONECAVE_52_3_SIUTE_2", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_SIUTE_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_3_SQ_2_start", "LIMESTONE_52_3_SQ_2", "Alright", "I'm busy"))
		{
			case 1:
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

		await dialog.Msg("LIMESTONE_52_3_SQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

