//--- Melia Script -----------------------------------------------------------
// Weakening Aura (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80126)]
public class Quest80126Script : QuestScript
{
	protected override void Load()
	{
		SetId(80126);
		SetName("Weakening Aura (1)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_MQ_10"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONECAVE_52_2_MEDENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_2_ALLENA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_1_start", "LIMESTONE_52_2_MQ_1", "Let's go.", "I don't think that's important."))
		{
			case 1:
				// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
				dialog.HideNPC("LIMESTONECAVE_52_2_MEDENA");
				// Func/LIMESTONE_52_2_MQ_RUNNPC;
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

		await dialog.Msg("LIMESTONE_52_2_MQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

