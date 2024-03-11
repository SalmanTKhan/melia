//--- Melia Script -----------------------------------------------------------
// One Final Step
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule.
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

[QuestScript(80158)]
public class Quest80158Script : QuestScript
{
	protected override void Load()
	{
		SetId(80158);
		SetName("One Final Step");
		SetDescription("Talk to Goddess Saule");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_9"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_10_start", "LIMESTONE_52_4_MQ_10", "We should leave right away.", "Let's go a bit later."))
		{
			case 1:
				// Func/LIMESTONE_52_4_REENTER_RUN;
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

		await dialog.Msg("LIMESTONE_52_4_MQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

